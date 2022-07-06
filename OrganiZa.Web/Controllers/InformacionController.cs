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
    public class InformacionController : Controller
    {
        HttpClient client = new HttpClient();
        string url = "http://organiza.somee.com/api/tutor";
        // GET: InformacionController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InformacionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InformacionController/Create
        public async Task<IActionResult> Create()
        {
            AgregarModels models = new AgregarModels();
            models.id = int.Parse(HttpContext.Session.GetString("Id"));
            models.Usuario = HttpContext.Session.GetString("Usuario");
            models.Rolusuario = HttpContext.Session.GetString("Rol");
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Pagos = JsonConvert.DeserializeObject<ApiResponse<List<TutorResponseDto>>>(json);
                var Tutores = await client.GetStringAsync("http://organiza.somee.com/api/escuela/");
                var Tutors = JsonConvert.DeserializeObject<ApiResponse<List<EscuelaRequestDto>>>(Tutores);
                foreach (var m in Tutors.Data)
                {
                    if (m.IdA == models.id)
                    {
                        models.Tutores = Pagos.Data.Where(x => x.IdE == m.Id).ToList();

                        break;
                    }
                }
                return View(models);

            }
            else

            {
                return RedirectToAction("Home", "Home");
            }
        }
        public IActionResult GenerarFicha()
        {
            Random r = new Random();
            int nAleatorio3 = r.Next(100000000, 900000000);
            int nAleatorio2 = r.Next(100000000, 900000000);
            string Numero = nAleatorio2.ToString() + nAleatorio3.ToString();
            TempData["mensaje"] = Numero;
            return RedirectToAction("Agregar");
        }
        public async Task<IActionResult> Agregar(int id)
        {
            AgregarModels pagoDto = new AgregarModels();
            pagoDto.id = int.Parse(HttpContext.Session.GetString("Id"));
            pagoDto.Usuario = HttpContext.Session.GetString("Usuario");
            pagoDto.Rolusuario = HttpContext.Session.GetString("Rol");
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync("http://organiza.somee.com/api/tutor/" + id);
                var _Pago = JsonConvert.DeserializeObject<ApiResponse<TutorRequestDto>>(json);
                pagoDto.Tutor = _Pago.Data;
                if (_Pago.Data.FichaPago != null)
                {
                    pagoDto.FichaPago = _Pago.Data.FichaPago;
                }
                else
                {
                    GenerarFicha();
                    if (TempData["mensaje"] != null)
                    {
                        pagoDto.FichaPago2 = TempData["mensaje"].ToString();

                    }
                    else
                    {
                        pagoDto.FichaPago = "";
                    }

                }

                return View(pagoDto);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Agregar(int Id, AgregarModels pagoDto)
        {
          
                pagoDto.id = int.Parse(HttpContext.Session.GetString("Id"));
                pagoDto.Usuario = HttpContext.Session.GetString("Usuario");
                pagoDto.Rolusuario = HttpContext.Session.GetString("Rol");
                var json = await client.GetStringAsync("http://organiza.somee.com/api/tutor/" + Id);
                var _Pago = JsonConvert.DeserializeObject<ApiResponse<TutorRequestDto>>(json);
                pagoDto.Tutor.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
                pagoDto.Tutor.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
                pagoDto.Tutor.FichaPago = pagoDto.FichaPago;
                pagoDto.Tutor.Alumno = _Pago.Data.Alumno;
                pagoDto.Tutor.NombreT = _Pago.Data.NombreT;
                pagoDto.Tutor.IdE = _Pago.Data.IdE;
                pagoDto.Tutor.Id = _Pago.Data.Id;
                pagoDto.Tutor.NombreE = _Pago.Data.NombreE;
                pagoDto.Tutor.Rolusuario = _Pago.Data.Rolusuario;
                pagoDto.Tutor.Usuario = _Pago.Data.Usuario;
                pagoDto.Tutor.Status = _Pago.Data.Status;
                var putTask = await client.PutAsJsonAsync("http://organiza.somee.com/api/tutor/?id=" + Id, pagoDto.Tutor);
                if (putTask.IsSuccessStatusCode)
                {
                    return RedirectToAction("Menu", "Administrador");
                }
            


            return View(pagoDto);
        }

        // POST: InformacionController/Create
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

        // GET: InformacionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InformacionController/Edit/5
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

        // GET: InformacionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InformacionController/Delete/5
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
