using OrganiZa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class DetailsCalendario
    {
        public int Id { get; set; }
        public string Rolusuario { get; set; }
        public string Usuario { get; set; }
        public CalendarioRequestDto Calendario { get; set; }
        public int id { get; set; }

        public List<CalendarioReponseDto> calendarios { get; set; }

        public EscuelaResponseDto Escuela { get; set; }
        public AdministradorResponseDto Admin { get; set; }

    }
}
