using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Shaker.WebUI.Controllers;
using Shaker.WebUI.Models;
using Shaker.WebUI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker.UnitTests.Models
{
    class DrinkConrollerTests
    {
        [Test]
        public void Index_WhenCalled_CheckIfDrinkReposiotryMethodIsCalled()
        {
            Mock<IDrinkRepository> dr = new();
            dr.Setup(dr => dr.GetAllCoctailsByLetterAsync('a'));
            DrinkController dc = new(dr.Object);

            dc.Index('a');

            dr.Verify(r => r.GetAllCoctailsByLetterAsync('a'));
        }

        [Test]
        public void Index_WithoutArgument_ReturnActionResult()
        {
            Mock<IDrinkRepository> dr = new();
            DrinkController dc = new(dr.Object);

            ViewResult actual = dc.Index() as ViewResult;

            Assert.That(actual.Model, Is.Null);
        }
    }
}
