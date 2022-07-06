using OrganiZa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class RecordatoriosModels
    {
        public List<TutorResponseDto> Tutor { get; set; }
        public EscuelaResponseDto Escuela { get; set; }

        public UsuarioResponseDto Usuarios { get; set; }
        public int Id { get; set; }
        public string Rolusuario { get; set; }
        public string Mensaje { get; set; }
        public string Correo { get; set; }
        public string Asunto { get; set; }



        public string Busqueda { get; set; }
        public string Usuario { get; set; }
    }
}
