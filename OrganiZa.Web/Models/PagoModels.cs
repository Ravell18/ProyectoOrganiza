using Microsoft.AspNetCore.Http;
using OrganiZa.Api.Responses;
using OrganiZa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class PagoModels
    {
        public PagoRequestDto pagos { get; set; }
        public TutorRequestDto Tutor { get; set; }
        public int Id { get; set; }
        public int IdE { get; set; }

        public string Rolusuario { get; set; }
        public string Usuario { get; set; }
        public string Alumno { get; set; }
        public string NombreT { get; set; }
        public string FichaPago { get; set; }
        public IFormFile file { get; set; }


    }
}
