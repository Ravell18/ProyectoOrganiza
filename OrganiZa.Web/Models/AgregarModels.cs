using OrganiZa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class AgregarModels
    {
        public int id { get; set; }
        public string Rolusuario { get; set; }
        public string Usuario { get; set; }
        public string FichaPago { get; set; }
        public string FichaPago2 { get; set; }
        public List<TutorResponseDto> Tutores { get; set; }
        public TutorRequestDto Tutor { get; set; }
  
    }
}
