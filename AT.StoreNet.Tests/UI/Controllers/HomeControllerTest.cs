using AT.StoreNet.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AT.StoreNet.Tests.UI.Controllers
{
    [TestClass, TestCategory("Controllers/HomeController")]
    public class HomeControllerTest
    {
        //Testar se na Home controller o método Index retorna a view...
        [TestMethod]
        public void TestandoIndexView()
        {
            //arrange
            var homeController = new HomeController();


            //act
            var result = homeController.Index();

            //assert
            Assert.AreEqual(typeof(ViewResult),result.GetType());


        }
    }
}
