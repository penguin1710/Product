using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Models;
using WebApplication1.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest1
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new ProductEntities();
            var controller = new ProductsController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<Product>));
            Assert.AreEqual(db.Products.Count(), (result.Model as List<Product>).Count);
        }

        [TestMethod]
        public void TestEdit()
        {
            var controller = new ProductsController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0,typeof(HttpNotFoundResult));

            var db = new ProductEntities();
            var item = db.Products.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as Product;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);
        }

        [TestMethod]
        public void TestCreate()
        {
            var controller = new ProductsController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
