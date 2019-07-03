using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class StoreWarehouseMessenger
    {
        private readonly MessageQueue _messageQueue;

        public StoreWarehouseMessenger(string queuePath, string description)
        {
            try
            {
                if (MessageQueue.Exists(queuePath))
                {
                    _messageQueue = new MessageQueue(queuePath);
                    _messageQueue.Label = description;
                }
                else
                {
                    MessageQueue.Create(queuePath);
                    _messageQueue = new MessageQueue(queuePath);
                    _messageQueue.Label = description;
                }
            }
            catch
            {
                throw new Exception("Error starting system queues");
            }

            _messageQueue.Formatter = new XmlMessageFormatter(new[] {
                typeof(ReplenishmentRequest),
            });
        }

        ~StoreWarehouseMessenger()
        {
            if (_messageQueue != null)
                _messageQueue.Dispose();
        }

        public void StartReceiving(ReceiveCompletedEventHandler receiveCompletedEventHandler)
        {
            _messageQueue.ReceiveCompleted += receiveCompletedEventHandler;
            _messageQueue.BeginReceive();
        }

        public void SendMessage(Object messageObject)
        {
            _messageQueue.Send(messageObject, "New Replenishment Request");
        }

        public Object ReceiveMessage()
        {
            return _messageQueue.Receive()?.Body;
        }
    }
}
