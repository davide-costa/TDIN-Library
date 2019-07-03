using Common;
using StoreRestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    [Serializable]
    class WarehouseData
    {
        public List<ReplenishmentRequest> _shippedReplenishmentRequests = new List<ReplenishmentRequest>();
        public List<ReplenishmentRequest> _replenishmentRequests = new List<ReplenishmentRequest>();
    }
}
