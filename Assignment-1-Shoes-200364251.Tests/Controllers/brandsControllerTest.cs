using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment_1_Shoes_200364251.Controllers;
using System.Web.Mvc;
using Assignment_1_Shoes_200364251.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_1_Shoes_200364251.Tests.Controllers
{
    [TestClass]
    public class brandsControllerTest
    {
        [TestMethod]
        public void IndexReturnsView()
        {

            //moq data
            Mock<IbrandsMock> mock;
            mock = new Mock<IbrandsMock>();

            List<brand> brands = new List<brand>
            {
                new brand {brandId = 3, brName = "Reebok", brDesc = "Sports and Lifestyle",
                    brFounder ="Joseph William Foster" },
                new brand {brandId = 4, brName = "Under Armour", brDesc = "Sports and Lifestyle",
                    brFounder ="Kevin Plank" }

            };

            mock.Setup(m => m.Brands).Returns(brands.AsQueryable()); 

            brandsController controller = new brandsController(mock.Object);

            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.AreEqual("Index", result.ViewName); 

        } 
    }
}
