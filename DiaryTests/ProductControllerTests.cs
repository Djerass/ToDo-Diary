using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoDiaryWeb.Controllers;
using ToDoDiaryWeb.Repositories;
using Xunit;
using ToDoDiaryWeb.Models;
using Product = ToDoDiaryWeb.Models.Product;
using ToDoDiaryWeb.ViewModels;

namespace DiaryTests
{
    public class ProductControllerTests
    {
        [Fact]
        public void IndexControllerPaginationTest()
        {
            //Arrage
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.GetAll()).Returns((new Product[]
            {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            }).AsQueryable<Product>());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            var result = controller.Index(null,2);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ListofProductViewModel>(
                viewResult.Model);
            // Assert
            Product[] prodArray = model.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);
            Assert.Equal(5,model.PageInfo.TotalItems);
            Assert.Equal(2,model.PageInfo.TotalPages);
        }
    }
}