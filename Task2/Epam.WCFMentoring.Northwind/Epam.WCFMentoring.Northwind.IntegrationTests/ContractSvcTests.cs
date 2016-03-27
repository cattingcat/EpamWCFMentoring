using Epam.WCFMentoring.Northwind.Services.CategorySvc;
using Epam.WCFMentoring.Northwind.Services.CategorySvc.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Epam.WCFMentoring.Northwind.IntegrationTests
{
    [TestClass]
    public class ContractSvcTests
    {
        private ICategoryService _categorySvc;

        [TestInitialize]
        public void ClassInit()
        {
            var categoruSvcFactory = new ChannelFactory<ICategoryService>("categorySvc");
            _categorySvc = categoruSvcFactory.CreateChannel();
        }

        [TestMethod]
        public void GetList()
        {
            var list = _categorySvc.GetCategories();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void GetDetails()
        {
            var cat = _categorySvc.GetCategories().First();
            var details = _categorySvc.GetDetails(new CategoryIdDTO { Id = cat.CategoryID });
            Assert.IsNotNull(details);
        }

        [TestMethod]
        public void UpdateDetails()
        {
            var cat = _categorySvc.GetCategories().First();
            var details = _categorySvc.GetDetails(new CategoryIdDTO { Id = cat.CategoryID });
            details.Picture = new MemoryStream(new byte[] { 1, 2, 3 });
            _categorySvc.UpdateCategory(details);
            Assert.IsNotNull(details);
        }
    }
}
