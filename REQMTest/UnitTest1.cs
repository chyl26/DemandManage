using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using REQM.Service;
using REQM.Domain;

namespace REQMTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProductService productCRUD = new ProductService();
            Product product = new Product();
            product.ProductId = "608840ba-f68c-49d4-bcc5-fc13452191cb";
            product.ProductName = "naaaqqame";
            product.Productlogic = "3333";
            product.user = new User();
            product.user.UserId = "46af4ae1-beca-4715-b5e5-0b8d576f0bc1";
            //Assert.AreEqual(3, 1);
            productCRUD.Update(product);
        }

        [TestMethod]
        public void TestMethod2()
        {
            ProductService productCRUD = new ProductService();
            Product product = new Product();
            product.ProductName = "naaaqqame";
            product.Productlogic = "3333";
            product.user = new User();
            product.user.UserId = "46af4ae1-beca-4715-b5e5-0b8d576f0bc1";
            //Assert.AreEqual(3, 1);
            productCRUD.Update(product);
        }
    }
}
