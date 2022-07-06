using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrganiZa.Api.Responses;
using OrganiZa.Domain.DTOs;
using OrganiZa.Domain.Entities;
using OrganiZa.Web.Models;

namespace OrganiZa.Web.Controllers
{
    public class RecordatoriosController : Controller
    {
        HttpClient client = new HttpClient();
        RecordatoriosModels ReDto2 = new RecordatoriosModels();


        // GET: RecordatoriosController


        // GET: RecordatoriosController/Details/5

        public async Task<IActionResult> Details(int Id)
        {
            RecordatoriosModels ReDto = new RecordatoriosModels();

            ReDto.Id = int.Parse(HttpContext.Session.GetString("Id"));
            ReDto.Usuario = HttpContext.Session.GetString("Usuario");
            ReDto.Rolusuario = HttpContext.Session.GetString("Rol");

            var pa = await client.GetStringAsync("http://organiza.somee.com/api/Usuario/");
            var pag = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(pa);
            foreach (var m in pag.Data)
            {
                if (m.IdT == Id)
                {
                    ReDto.Usuarios = m;

                    break;
                }


            }
           
            return View(ReDto);


        }
        [HttpPost]
        public async Task<IActionResult> Details(RecordatoriosModels email,int Id)
        {

            RecordatoriosModels ReDto = new RecordatoriosModels();

            ReDto.Id = int.Parse(HttpContext.Session.GetString("Id"));
            ReDto.Usuario = HttpContext.Session.GetString("Usuario");
            ReDto.Rolusuario = HttpContext.Session.GetString("Rol");

            var pa = await client.GetStringAsync("http://organiza.somee.com/api/Usuario/");
            var pag = JsonConvert.DeserializeObject<ApiResponse<List<UsuarioResponseDto>>>(pa);
            foreach (var m in pag.Data)
            {
                if (m.IdT == Id)
                {
                    ReDto.Usuarios = m;

                    break;
                }


            }
            try
            {
                // Credentials
                var credentials = new NetworkCredential("SunnySchool012@gmail.com", "mdjcm0021");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("sunnyschool012@gmail.com", "Coordinacion"),
                    Subject = email.Asunto,
                    Body = email.Mensaje,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(ReDto.Usuarios.Usuario));

                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };

                // Send it...         
                client.Send(mail);
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }


            return View(ReDto);
      


        }

       





        public async Task<IActionResult> Index(RecordatoriosModels models2)
        {
            models2.Id = int.Parse(HttpContext.Session.GetString("Id"));
            models2.Usuario = HttpContext.Session.GetString("Usuario");
            models2.Rolusuario = HttpContext.Session.GetString("Rol");
            var Tutores = await client.GetStringAsync("http://organiza.somee.com/api/tutor/");
            var Tutors = JsonConvert.DeserializeObject<ApiResponse<List<TutorResponseDto>>>(Tutores);
            var pa = await client.GetStringAsync("http://organiza.somee.com/api/Escuela/");
            var pag = JsonConvert.DeserializeObject<ApiResponse<List<EscuelaResponseDto>>>(pa);
            foreach (var m in pag.Data)
            {
                if( m.IdA == models2.Id)
                {
                    models2.Escuela = pag.Data.Where(x=>x.IdA == models2.Id).FirstOrDefault();

                    break;

                }

            }
            foreach (var m in Tutors.Data)
            {

                models2.Tutor = Tutors.Data.Where(x=>x.IdE == models2.Escuela.Id).ToList();

                break;

            }
            var movies = from m in models2.Tutor
                         select m;

            if (!String.IsNullOrEmpty(models2.Busqueda))
            {
                movies = movies.Where(s => s.NombreT.Contains(models2.Busqueda));
                models2.Tutor = movies.ToList();

            }


            return View(models2);
        }

        // GET: RecordatoriosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecordatoriosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecordatoriosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecordatoriosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RecordatoriosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecordatoriosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
