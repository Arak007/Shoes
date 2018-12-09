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
        Mock<IBrandsMock> mock;
        List<brand> Brands;
        brandsController controller;

        [TestInitialize]
        public void TestInitialize()
        {

            //moq data

            mock = new Mock<IBrandsMock>();
             
            //moq data
            
            mock = new Mock<IBrandsMock>();
            Brands = new List<brand>
            {
                new brand {brandId = 3, brName = "Reebok", brDesc = "Sports and Lifestyle",
                    brFounder ="Joseph William Foster" },

                new brand {brandId = 4, brName = "Under Armour", brDesc = "Sports and Lifestyle",
                    brFounder ="Kevin Plank" }

            };

            mock.Setup(m => m.Brands).Returns(Brands.AsQueryable());

            controller = new brandsController(mock.Object);
            


        }
        [TestMethod]
        public void IndexReturnsView()
        {
            ViewResult result = controller.Index() as ViewResult;



            //assert
            Assert.AreEqual("Index", result.ViewName); 

        } 
        [TestMethod]
        public void IndexReturnsBrands()
        {
            //act
            var actual = (List<brand>)((ViewResult)controller.Index()).Model;

            //assert
            CollectionAssert.AreEqual(Brands.OrderBy(a => a.brName).ThenBy(a => a.brFounder).ToList(), actual);

        }

        [TestMethod]

        public void DetailsNoId()
        {
            var actual = (ViewResult)controller.Details(null);

            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            var actual = (ViewResult)controller.Details(43567890);

            Assert.AreEqual("Error", actual.ViewName);
        }

        [TestMethod]
        public void DetailsValidId()
        {
             brand actual = (brand)((ViewResult)controller.Details(3)).Model;

            Assert.AreEqual(Brands[0], actual);

        }

        [TestMethod]
        public void DetailsViewLoads()
        {
            ViewResult result = (ViewResult)controller.Details(3);

            Assert.AreEqual("Details", result.ViewName);

        }

          
           
    }
}
