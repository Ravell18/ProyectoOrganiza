using OrganiZa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class BuscarModels
    {
        public List<EscuelaResponseDto> Escuela { get; set; }
        public string Busqueda { get; set; }
        public string Usuario { get; set; }

    }
}
