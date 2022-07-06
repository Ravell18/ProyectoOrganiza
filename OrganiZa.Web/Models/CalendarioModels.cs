using OrganiZa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class CalendarioModels
    {
        public int Id { get; set; }
        public string Rolusuario { get; set; }
        public string Usuario { get; set; }
        public CalendarioRequestDto Calendario { get; set; }
        public int id { get; set; }
        
        public EscuelaResponseDto Escuelas { get; set; }

    }
}
