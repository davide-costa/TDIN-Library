using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using Common;
using StoreRestService;

public partial class _Default : Page
{
    StoreRestServiceProxy storeRestServiceProxy = new StoreRestServiceProxy();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            LoadBooksAndAvailability();
    }

    private void LoadBooksAndAvailability()
    {
        BooksAndAvailability booksAndAvailability = storeRestServiceProxy.GetBooksListAndAvailability();

        DataTable dataTable = new DataTable();
        dataTable.Clear();
        dataTable.Columns.Add("Book Id");
        dataTable.Columns.Add("Book Title");
        dataTable.Columns.Add("Book Price");
        dataTable.Columns.Add("Book Availability");
        dataTable.Columns.Add("Quantity");

        List<BookData> books = booksAndAvailability.books;
        List<int> availabilities = booksAndAvailability.availabilities;
        for (int i = 0; i < books.Count; i++)
        {
            DataRow newRow = dataTable.NewRow();
            newRow["Book Id"] = books[i].Id;
            newRow["Book Title"] = books[i].Title;
            newRow["Book Price"] = books[i].Price;
            newRow["Book Availability"] = availabilities[i];
            newRow["Quantity"] = 0;
            dataTable.Rows.Add(newRow);
        }
        BooksAndAvalabilityGridView.DataSource = dataTable;

        BooksAndAvalabilityGridView.DataBind();
        BooksAndAvalabilityGridView.Columns[0].Visible = true; //set buttons column visible
        BooksAndAvalabilityGridView.Visible = true;
    }

    protected void OnSubmitOrderButtonClick(object sender, EventArgs e)
    {
        ClearUserMessage();
        string clientEmail = emailTextBox.Text;
        if (clientEmail.Length == 0)
        {
            ShowUserErrorMessage("Your must introduce your email first!");
            return;
        }

        Dictionary<int, int> booksAndAvailabilities = GetSelectBooksAndQuantities();
        if (booksAndAvailabilities.Count == 0)
        {
            ShowUserErrorMessage("Your must select some books first!");
            return;
        }

        BasicOrderData newBasicOrderData = new BasicOrderData();
        newBasicOrderData.BooksIds = new List<int>(booksAndAvailabilities.Keys);
        newBasicOrderData.BooksQuantity = new List<int>(booksAndAvailabilities.Values);
        try
        {
            storeRestServiceProxy.RegisterOrdersListByClientEmail(clientEmail, newBasicOrderData);
            ShowUserSuccessMessage("Order sucessfully submited!");
        }
        catch (Exception)
        {
            ShowUserErrorMessage("Email not associated to any account!");
        }

    }

    private Dictionary<int, int> GetSelectBooksAndQuantities()
    {
        Dictionary<int, int> booksAndAvailabilities = new Dictionary<int, int>();
        foreach (GridViewRow gridViewRow in BooksAndAvalabilityGridView.Rows)
        {
            int quantity = Convert.ToInt32(gridViewRow.Cells[5].Text);
            gridViewRow.Cells[5].Text = "0";
            if (quantity <= 0)
                continue;

            int bookId = Convert.ToInt32(gridViewRow.Cells[1].Text);
            booksAndAvailabilities.Add(bookId, quantity);
        }

        return booksAndAvailabilities;
    }


    protected void OnSwitchTableButtonClick(object sender, EventArgs e)
    {
        ClearUserMessage();
        if (switchTableButton.Text == "Make an order")
            OnBookListForPurchaseRequest();
        else
            OnCheckOrdersRequest();
    }

    private void OnCheckOrdersRequest()
    {
        if (emailTextBox.Text.Length == 0)
        {
            ShowUserErrorMessage("Your must introduce your email first!");
            return;
        }
        string email = emailTextBox.Text;

        try
        {
            List<OrderToDisplay> orders = storeRestServiceProxy.GetOrders(email);
            FillClientOrdersListDataGridView(orders);
        }
        catch (Exception)
        {
            ShowUserErrorMessage("Error retrieving your orders!");
            return;
        }

        switchTableButton.Text = "Make an order";
        BooksAndAvalabilityGridView.Visible = false;
        ClientOrdersGridView.Visible = true;
        submitOrderButton.Visible = false;
    }

    private void OnBookListForPurchaseRequest()
    {
        LoadBooksAndAvailability();
        switchTableButton.Text = "Check Your Orders";
        BooksAndAvalabilityGridView.Visible = true;
        ClientOrdersGridView.Visible = false;
        submitOrderButton.Visible = true;
    }

    private void FillClientOrdersListDataGridView(List<OrderToDisplay> orders)
    {
        DataTable dataTable = new DataTable();
        dataTable.Clear();
        dataTable.Columns.Add("Books Titles");
        dataTable.Columns.Add("Books Quantities");
        dataTable.Columns.Add("Books Prices");
        dataTable.Columns.Add("Total Price");
        dataTable.Columns.Add("State");


        foreach (OrderToDisplay orderToDisplay in orders)
        {
            string booksTitles = "";
            string booksQuantitiesString = "";
            string booksPrices = "";

            List<BookData> bookDatas = orderToDisplay.books;
            List<int> bookQuantitiesList = orderToDisplay.quantity;
            for (int i = 0; i < bookDatas.Count; i++)
            {
                BookData bookData = bookDatas[i];
                booksTitles += bookData.Title + "  ";
                booksQuantitiesString += bookQuantitiesList[i] + "  "; ;
                booksPrices += bookData.Price + "  "; ;
            }

            DataRow newRow = dataTable.NewRow();
            newRow["Books Titles"] = booksTitles;
            newRow["Books Quantities"] = booksQuantitiesString;
            newRow["Books Prices"] = booksPrices;
            newRow["Total Price"] = orderToDisplay.totalPrice;
            newRow["State"] = orderToDisplay.state;
            dataTable.Rows.Add(newRow);
        }

        ClientOrdersGridView.DataSource = dataTable;
        ClientOrdersGridView.DataBind();
    }

    private void ShowUserMessage(string message, Color color)
    {
        userShowMessages.Text = message;
        userShowMessages.ForeColor = color;
        userShowMessages.Visible = true;
    }

    private void ShowUserErrorMessage(string message)
    {
        ShowUserMessage(message, Color.DarkRed);
    }

    private void ShowUserSuccessMessage(string message)
    {
        ShowUserMessage(message, Color.Green);
    }

    private void ClearUserMessage()
    {
        userShowMessages.Text = "";
        userShowMessages.Visible = false;
    }

    protected void IncrementBookTitleQuantity(object sender, CommandEventArgs e)
    {
        int id = Int32.Parse(e.CommandArgument.ToString());
        foreach (GridViewRow gridViewRow in BooksAndAvalabilityGridView.Rows)
        {
            if (gridViewRow.Cells[1].Text == id.ToString())
            {
                int oldValue = Convert.ToInt32(gridViewRow.Cells[5].Text);
                gridViewRow.Cells[5].Text = (oldValue + 1).ToString();
            }
        }
    }

    protected void DecrementBookTitleQuantity(object sender, CommandEventArgs e)
    {
        int id = Int32.Parse(e.CommandArgument.ToString());
        foreach (GridViewRow gridViewRow in BooksAndAvalabilityGridView.Rows)
        {
            if (gridViewRow.Cells[1].Text == id.ToString())
            {
                int oldValue = Convert.ToInt32(gridViewRow.Cells[5].Text);
                if(oldValue > 0)
                    gridViewRow.Cells[5].Text = (oldValue - 1).ToString();
            }
        }
    }

}

