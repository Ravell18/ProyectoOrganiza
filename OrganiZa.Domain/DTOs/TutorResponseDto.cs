using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiZa.Domain.DTOs
{
    public class TutorResponseDto
    {
        public int Id { get; set; }
        public string Rolusuario { get; set; }
        public string Usuario { get; set; }
        public string Alumno { get; set; }
        public string NombreT { get; set; }
        public double Telefono { get; set; }
        public string NombreE { get; set; }
        public string FichaPago { get; set; }
        public int IdE { get; set; }
        public int? UsersId { get; set; }
        public int? EscuelaModelsId { get; set; }
        public int? CalendarioModelsId { get; set; }
        public int? PagosModelsId { get; set; }

        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
