using Epam.WCFMentoring.Northwind.Services.OrderSvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Collections;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;
using System.Diagnostics;

namespace Epam.WCFMentoring.Northwind.ServicesImpl.OrderSvc
{
    public class PubSubServiceImpl: IPubSubService
    {
        private static ISet<IStatusChangeCallback> _callbacks = new HashSet<IStatusChangeCallback>();

        public static void NotifyAll(OrderDTO order)
        {
            Debug.WriteLine("Notify all for OrderId: {0} fired!", order.OrderID);
            lock (_callbacks)
            {
                var unavailableClients = new List<IStatusChangeCallback>();
                foreach (var client in _callbacks)
                {
                    try
                    {
                        client.StatusChange(order);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        unavailableClients.Add(client);
                    }
                }

                foreach (var client in unavailableClients)
                {
                    _callbacks.Remove(client);
                }
            }
        }

        public void Subscribe()
        {
            var cb = OperationContext.Current.GetCallbackChannel<IStatusChangeCallback>();
            lock (_callbacks)
            {
                bool isAdded = _callbacks.Add(cb);
                if (!isAdded)
                {
                    Debug.WriteLine("Callback client not added");
                }
            }
        }

        public void Unsubscribe()
        {
            var cb = OperationContext.Current.GetCallbackChannel<IStatusChangeCallback>();
            lock (_callbacks)
            {
               bool isRemoved = _callbacks.Remove(cb);
               if (!isRemoved)
               {
                   Debug.WriteLine("Callback client not removed");
               }
            }
        }
    }
}
