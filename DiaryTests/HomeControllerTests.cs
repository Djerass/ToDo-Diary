using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Diary.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ToDoDiaryWeb.Controllers;
using ToDoDiaryWeb.Models;
using Xunit;

namespace DiaryTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void TestName()
        {
        //Given
        ClaimsPrincipal User = new ClaimsPrincipal();
        var mock = new Mock<IToDoRepository>();
            mock.SetupGet(rep=>rep.GetAll).Returns(GetList());
        var mock2 =new Mock<Iid>();
        mock2.Setup(id=>id.TakaId(User)).Returns(1.ToString);
            var controller = new HomeController(mock.Object,mock2.Object);
            
        //When
        var result = controller.Index();
        
        //Then
        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<ToDo>>(viewResult.Model);
        Assert.Equal(GetList().Where(i=>i.UserId=="1").ToList().Count, model.Count());
        }
        private List<ToDo> GetList()
        {
        return new List<ToDo>{
            new ToDo{Id=1,Description="Run",Status=true,Date=DateTime.Now,UserId="1"},
            new ToDo{Id=2,Description="Sit",Status=false,Date=DateTime.Now,UserId="1"},
            new ToDo{Id=3,Description="Sleep",Status=true,Date=DateTime.Now,UserId="1"},
            new ToDo{Id=3,Description="Sleep",Status=true,Date=DateTime.Now,UserId="2"},
        };
        }
        [Fact]
        public void CookiSwapTest()
        {
        //Given
         ClaimsPrincipal User = new ClaimsPrincipal();
        var mock = new Mock<IToDoRepository>();
            mock.SetupGet(rep=>rep.GetAll).Returns(GetList());
        var mock2 =new Mock<Iid>();
        mock2.Setup(id=>id.TakaId(User)).Returns(1.ToString);
            var controller = new HomeController(mock.Object,mock2.Object);
        //When
        var result = controller.ChangeViewtoAll();
        var viewResult = Assert.IsType<ViewResult>(result);
       
        //Then
        Assert.Equal("All", controller.Request.Cookies["Show"].ToString());
        }
    }
}