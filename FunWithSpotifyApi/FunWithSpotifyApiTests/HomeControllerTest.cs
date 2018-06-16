using FunWithSpotifyApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace FunWithSpotifyApiTests
{
    [TestFixture]
    public class HomeControllerTest
    {
        private HomeController _controller;
        private const string ViewName = "Index";

        [SetUp]
        public void TestSetUp()
        {
            _controller = new HomeController();
        }

        [Test]
        public void HomeController_GetView_ShouldReturnIndexView()
        {
            var result = _controller.Index();
            Assert.IsInstanceOf(typeof(IActionResult),result);
        }
    }
}
