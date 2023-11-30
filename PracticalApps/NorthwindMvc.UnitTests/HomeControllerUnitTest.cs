using Northwind.Mvc.Controllers;
using Moq;
using Microsoft.Extensions.Logging;

namespace NorthwindMvc.UnitTests
{
    public class HomeControllerUnitTest
    {
        [Fact]
        public async Task CategoryDetailReturnsBadRequestWhenIdIsNull()
        {
            //arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var controller = new HomeController(mockLogger);
        }
    }
}