using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrganiZa.Api.Responses;
using OrganiZa.Domain.DTOs;
using OrganiZa.Web.Models;

namespace OrganiZa.Web.Controllers
{
    public class AdministradorController : Controller
    {
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Details(int Id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                Id = int.Parse(HttpContext.Session.GetString("Id"));

                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("http://organiza.somee.com/api/Administrador/" + Id);
                var admi = JsonConvert.DeserializeObject<ApiResponse<AdministradorResponseDto>>(Json);
                admi.Data.Usuario = HttpContext.Session.GetString("Usuario");
                return View(admi.Data);
            }
            else
            {
                return RedirectToAction("Menu", "Administrador");
            }

        }
        public IActionResult Menu(MenuAModel Menu)
        {
            if(HttpContext.Session.GetString("Id")!=null)
            {
                Menu.id = int.Parse(HttpContext.Session.GetString("Id"));
                Menu.Rolusuario = HttpContext.Session.GetString("Rol");
                Menu.Usuario = HttpContext.Session.GetString("Usuario");
                return View(Menu);

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegistroAModels admin)
        {

            AdministradorRequestDto adminRequestDto = admin.Administrador;
            admin.Administrador.Rolusuario = "Administrador";
            var Json = await client.PostAsJsonAsync("http://organiza.somee.com/api/Administrador/", adminRequestDto);
            var Tutor = await client.GetStringAsync("http://organiza.somee.com/api/Administrador/");
            var Tutors = JsonConvert.DeserializeObject<ApiResponse<List<AdministradorResponseDto>>>(Tutor);
            UsuarioRequestDto usuarioRequestDto = admin.Usuario;
            if (Json.IsSuccessStatusCode)
            {
                admin.Usuario.Rolusuario = "Administrador";
                admin.Usuario.IdA = Tutors.Data.Last().Id;
            }
            var Json2 = await client.PostAsJsonAsync("http://organiza.somee.com/api/usuario/", usuarioRequestDto);
            if (Json.IsSuccessStatusCode && Json2.IsSuccessStatusCode)
            {
                return RedirectToAction("Home", "Home");
            }
            return View(admin);
        }

        public async Task<IActionResult> Update(int Id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                Id = int.Parse(HttpContext.Session.GetString("Id"));

                var httpClient = new HttpClient();
                var Json = await httpClient.GetStringAsync("http://organiza.somee.com/api/Administrador/" + Id);
                var admin = JsonConvert.DeserializeObject<ApiResponse<AdministradorRequestDto>>(Json);
                admin.Data.Usuario = HttpContext.Session.GetString("Usuario");


                return View(admin.Data);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Update(int Id, AdministradorRequestDto tutor)
        {

            Id = int.Parse(HttpContext.Session.GetString("Id"));

            tutor.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
            tutor.Id = int.Parse(HttpContext.Session.GetString("Id"));
            tutor.Rolusuario = HttpContext.Session.GetString("Rol");
            tutor.Usuario = HttpContext.Session.GetString("Usuario");
            var putTask = await client.PutAsJsonAsync("http://organiza.somee.com/api/Administrador/?id=" + Id, tutor);
            if (putTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Details");
            }

            return View(tutor);
        }

    }
}
