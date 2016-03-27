using Epam.WCFMentoring.Northwind.Services.OrderSvc;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WCFMentoring.Northwind
{
    class CallbackClass: IStatusChangeCallback
    {
        public void StatusChange(OrderDTO order)
        {
            Console.WriteLine("Order changed: {0}", order.OrderID);
        }
    }
}
