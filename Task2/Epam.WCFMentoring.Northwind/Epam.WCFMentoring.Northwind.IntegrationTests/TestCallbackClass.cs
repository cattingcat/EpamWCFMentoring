using Epam.WCFMentoring.Northwind.Services.OrderSvc;
using Epam.WCFMentoring.Northwind.Services.OrderSvc.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WCFMentoring.Northwind.IntegrationTests
{
    class TestCallbackClass: IStatusChangeCallback
    {
        public OrderDTO ChangedOrder { get; set; }

        public void StatusChange(OrderDTO order)
        {
            ChangedOrder = order;
        }
    }
}
