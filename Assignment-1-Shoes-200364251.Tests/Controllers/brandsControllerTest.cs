using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_1_Shoes_200364251.Controllers;
using System.Web.Mvc;

namespace Assignment_1_Shoes_200364251.Tests.Controllers
{
    [TestClass]
    public class brandsControllerTest
    {
        [TestMethod]
        public void IndexReturnsView()
        {
            brandsController controller = new brandsController();

            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.AreEqual("Index", result.ViewName); 

        } 
    }
}
