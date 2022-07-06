using OrganiZa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class ComprobacionModels
    {
        public int id { get; set; }
        public string Rolusuario { get; set; }
        public string Usuario { get; set; }
        public List<PagoResponseDto> Pagos { get; set; }

    }
}
