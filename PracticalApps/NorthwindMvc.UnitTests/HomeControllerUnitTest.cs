using Northwind.Mvc.Controllers;
using Moq;
using Microsoft.Extensions.Logging;
using Packt.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace NorthwindMvc.UnitTests
{
    public class HomeControllerUnitTest
    {
        [Fact]
        public async Task CategoryDetailReturnsBadRequestWhenIdIsNull()
        {
            //arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var mockDbContext = new Mock<NorthwindContext>();
            
            var controller = new HomeController(mockLogger.Object, mockDbContext.Object);

            int? id = null;

            //Act
            var result = await controller.CategoryDetail(id);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task CategoryDetailReturnsNotFoundWhenCategoryNotFound()
        {
            //arrange
            int? id = 10000;    //id is valid but dosen't exist
            var mockLogger = new Mock<ILogger<HomeController>>();
            var mockDbContext = new Mock<NorthwindContext>();

            var controller = new HomeController(mockLogger.Object, mockDbContext.Object);

            //Act
            var result = await controller.CategoryDetail(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task ProductDetailReturnsBadRequestWhenIdIsNull()
        {
            //arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var mockDbContext = new Mock<NorthwindContext>();

            var controller = new HomeController(mockLogger.Object, mockDbContext.Object);

            int? id = null;

            //act 
            var result = await controller.ProductDetail(id);

            //assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        //[Fact]
        //public async Task ProductDetailReturnsNotFoundWhenProductNotFound()
        //{
        //    // Arrange
        //    var mockLogger = new Mock<ILogger<HomeController>>();
        //    var options = new DbContextOptionsBuilder<NorthwindContext>()
        //        .UseInMemoryDatabase(databaseName: "TestDatabase")
        //        .Options;
        //
        //    using var dbContext = new NorthwindContext(options);
        //    var productId = 1;
        //    dbContext.Products.Add(new Product { ProductId = productId });
        //    dbContext.SaveChanges();
        //
        //    var controller = new HomeController(mockLogger.Object, dbContext);
        //    //act
        //    var result = await controller.ProductDetail(id);
        //
        //    //assert
        //    Assert.IsType<NotFoundObjectResult>(result);
        //}

        [Fact]
        public async Task ProductDetail_Returns_NotFound_When_ProductNotFound()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<HomeController>>();
            var dbContextMock = new Mock<NorthwindContext>();
            dbContextMock.Setup(db => db.Products.SingleOrDefaultAsync(It.IsAny<Expression<Func<Product, bool>>>(), default))
                .ReturnsAsync((Product)null);

            var controller = new HomeController(mockLogger.Object,dbContextMock.Object);

            // Act
            var result = await controller.ProductDetail(999); // Assuming this ID does not exist

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}