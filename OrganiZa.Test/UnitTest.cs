using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OrganiZa.Web.Controllers;
using OrganiZa.Web.Models;
using Xunit;
using System.Net.Http;

namespace OrganiZa.Test
{


    public class UnitTest
    {
        public HomeController ObjHomeController { get; }

        public UnitTest()
        {
            ObjHomeController = new HomeController();
            //DataFaker = new Faker();
        }

        [Fact]
        public async Task DatosCorrectosAsync()
        {

            LoginModel login = new LoginModel
            {
                Usuario = "Missael655@h.com",
                Contraseña = "123"
            };


            var result = await ObjHomeController.IndexAsync(login) as RedirectToActionResult;
            Assert.Equal("Home", result.ActionName);
        }
        [Fact]
        public async Task SinUsuarioyContraseña()
        {
            LoginModel login = new LoginModel
            {

            };
            var result = await ObjHomeController.IndexAsync(login) as ViewResult;
            Assert.Null(result.ViewName);
        }
        [Fact]
        public async Task VacioAsync()
        {
            LoginModel login = new LoginModel();
            var result = await ObjHomeController.IndexAsync(login) as ViewResult;
            Assert.Null(result.Model);
        }

        [Fact]
        public async Task SinContraseñaAsync()
        {
            LoginModel login = new LoginModel()
            {
                Usuario = "Missael655@h.com2",
            };
            var result = await ObjHomeController.IndexAsync(login) as ViewResult;
            Assert.Null(result.ViewName);
        }
        [Fact]
        public async Task SinUsuarioAsync()
        {
            LoginModel login = new LoginModel()
            {
                Contraseña = "123"
            };
            var result = await ObjHomeController.IndexAsync(login) as ViewResult;
            Assert.Null(result.ViewName);
        }
    }
}