using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    public class PagosController : Controller
    {
        HttpClient client = new HttpClient();
        string url = "http://organiza.somee.com/api/pago";
        bool bolean = false;

        public IActionResult PagoExito()
        {
            return View();
        }
        public async Task<IActionResult> Historial()
        {
            HistorialModels models = new HistorialModels();
            models.id = int.Parse(HttpContext.Session.GetString("Id"));
            models.Usuario = HttpContext.Session.GetString("Usuario");
            models.Rolusuario = HttpContext.Session.GetString("Rol");
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Pagos = JsonConvert.DeserializeObject<ApiResponse<List<PagoResponseDto>>>(json);
                var pa = await client.GetStringAsync("http://organiza.somee.com/api/pago/");
                var pag = JsonConvert.DeserializeObject<ApiResponse<List<PagoRequestDto>>>(pa);
                foreach (var m in pag.Data)
                {
                    if (m.TutorId == models.id)
                    {
                        models.Pagos = Pagos.Data.Where(x => x.TutorId == m.TutorId).ToList();

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
        public async Task<IActionResult> Comprobacion()
        {
            ComprobacionModels models = new ComprobacionModels();
            models.id = int.Parse(HttpContext.Session.GetString("Id"));
            models.Usuario = HttpContext.Session.GetString("Usuario");
            models.Rolusuario = HttpContext.Session.GetString("Rol");
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync(url);
                var Pagos = JsonConvert.DeserializeObject<ApiResponse<List<PagoResponseDto>>>(json);
                var Tutores = await client.GetStringAsync("http://organiza.somee.com/api/escuela/");
                var Tutors = JsonConvert.DeserializeObject<ApiResponse<List<EscuelaRequestDto>>>(Tutores);
                foreach (var m in Tutors.Data)
                {
                    if (m.IdA == models.id)
                    {
                        models.Pagos = Pagos.Data.Where(x => x.IdE == m.Id).ToList();

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
        public async Task<IActionResult> Aprobacion(int id)
        {
            AprobacionModels pagoDto = new AprobacionModels();

            pagoDto.Id = int.Parse(HttpContext.Session.GetString("Id"));
            pagoDto.Usuario = HttpContext.Session.GetString("Usuario");
            pagoDto.Rolusuario = HttpContext.Session.GetString("Rol");
            if (HttpContext.Session.GetString("Id") != null)
            {
                var json = await client.GetStringAsync("http://organiza.somee.com/api/pago/" + id);
                var _Pago = JsonConvert.DeserializeObject<ApiResponse<PagoRequestDto>>(json);
                pagoDto.pagos = _Pago.Data;
                return View(pagoDto);
            }
            else
            {
                return RedirectToAction("Home", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Aprobacion(int Id, AprobacionModels pagoDto)
        {
            pagoDto.Id = int.Parse(HttpContext.Session.GetString("Id"));
            pagoDto.Usuario = HttpContext.Session.GetString("Usuario");
            pagoDto.Rolusuario = HttpContext.Session.GetString("Rol");
            if (pagoDto.pagos.Statusdepago == null)
            {
                pagoDto.Id = int.Parse(HttpContext.Session.GetString("Id"));
                pagoDto.Usuario = HttpContext.Session.GetString("Usuario");
                pagoDto.Rolusuario = HttpContext.Session.GetString("Rol");
                var json = await client.GetStringAsync("http://organiza.somee.com/api/pago/" + Id);
                var _Pago = JsonConvert.DeserializeObject<ApiResponse<PagoRequestDto>>(json);
                pagoDto.pagos.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
                pagoDto.pagos.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
                pagoDto.pagos.Fichapago = _Pago.Data.Fichapago;
                pagoDto.pagos.Voucher = _Pago.Data.Voucher;
                pagoDto.pagos.Mespagado = _Pago.Data.Mespagado;
                pagoDto.pagos.Fecha = _Pago.Data.Fecha;
                pagoDto.pagos.IdE = _Pago.Data.IdE;
                do
                {

                    var putTask = await client.PutAsJsonAsync("http://organiza.somee.com/api/pago/?id=" + Id, pagoDto.pagos);
                    if (putTask.IsSuccessStatusCode)
                    {
                        bolean = true;
                        return RedirectToAction("Menu", "Administrador");
                    }


                } while (bolean == true);


            }
            else
            {
                var json = await client.GetStringAsync("http://organiza.somee.com/api/pago/" + Id);
                var _Pago = JsonConvert.DeserializeObject<ApiResponse<PagoRequestDto>>(json);
                pagoDto.pagos.UpdatedBy = int.Parse(HttpContext.Session.GetString("Id"));
                pagoDto.pagos.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
                pagoDto.pagos.Fichapago = _Pago.Data.Fichapago;
                pagoDto.pagos.Voucher = _Pago.Data.Voucher;
                pagoDto.pagos.Mespagado = _Pago.Data.Mespagado;
                pagoDto.pagos.Fecha = _Pago.Data.Fecha;
                pagoDto.pagos.IdE = _Pago.Data.IdE;
                do
                {
                   
                    var putTask = await client.PutAsJsonAsync("http://organiza.somee.com/api/pago/?id=" + Id, pagoDto.pagos);
                   if( putTask.IsSuccessStatusCode)
                    {
                        bolean = true;
                        return RedirectToAction("Menu", "Administrador");
                    }
                   

                } while (bolean == true);
               
                
            }
            
            
            return View(pagoDto);
        }

        public async Task<IActionResult> Create()
        {
            PagoModels tutor = new PagoModels();
            tutor.Id = int.Parse(HttpContext.Session.GetString("Id"));
            tutor.Rolusuario = HttpContext.Session.GetString("Rol");
            tutor.Usuario = HttpContext.Session.GetString("Usuario");
            var Tutores = await client.GetStringAsync("http://organiza.somee.com/api/Tutor/");
            var Tutors = JsonConvert.DeserializeObject<ApiResponse<List<TutorRequestDto>>>(Tutores);
            foreach (var m in Tutors.Data)
            {
                if (m.Id == tutor.Id)
                {
                    tutor.Alumno = m.Alumno;
                    tutor.NombreT = m.NombreT;
                    if (m.FichaPago == null)
                    {
                        tutor.FichaPago = "No tiene aun una ficha de pago asignada";

                    }
                    else
                    {
                        tutor.FichaPago = m.FichaPago;
                    }

                    break;
                }
            }

            return View(tutor);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PagoModels admin)
        {
            admin.Id = int.Parse(HttpContext.Session.GetString("Id"));
            admin.Rolusuario = HttpContext.Session.GetString("Rol");
            admin.Usuario = HttpContext.Session.GetString("Usuario");
            admin.pagos.Fichapago = admin.FichaPago;
            if (admin.file != null && admin.FichaPago != null && admin.pagos.Mespagado != null)
            {
                var Tutores = await client.GetStringAsync("http://organiza.somee.com/api/Tutor/");
                var Tutors = JsonConvert.DeserializeObject<ApiResponse<List<TutorRequestDto>>>(Tutores);
                foreach (var m in Tutors.Data)
                {
                    if (m.Id == admin.Id)
                    {
                        admin.Alumno = m.Alumno;
                        admin.NombreT = m.NombreT;
                        admin.FichaPago = m.FichaPago;
                        admin.IdE = m.IdE;
                        break;
                    }
                }
                PagoRequestDto adminRequestDto = admin.pagos;
                using (var target = new MemoryStream())
                {
                    admin.file.CopyTo(target);

                    admin.pagos.Voucher = target.ToArray();
                }
                admin.pagos.TutorId = int.Parse(HttpContext.Session.GetString("Id"));
                admin.pagos.CreatedBy = int.Parse(HttpContext.Session.GetString("Id"));
                admin.pagos.Alumno = admin.Alumno;
                admin.pagos.NombreT = admin.NombreT;
                admin.pagos.Fichapago = admin.FichaPago;
                admin.pagos.Fecha = DateTime.Now;
                admin.pagos.IdE = admin.IdE;
                admin.pagos.CreateAt = DateTime.Now;
                admin.pagos.TutorId = int.Parse(HttpContext.Session.GetString("Id"));
                var Json = await client.PostAsJsonAsync("http://organiza.somee.com/api/pago/", adminRequestDto);
                if (Json.IsSuccessStatusCode)
                {
                    return RedirectToAction("PagoExito");
                }
            }

            return View(admin);
        }

    }
}
