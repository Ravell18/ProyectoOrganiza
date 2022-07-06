using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiZa.Domain.DTOs
{
    public class AdministradorResponseDto
    {
        public int Id { get; set; }

        public string Rolusuario { get; set; }
        public string NombreAd { get; set; }
        public int? UsersId { get; set; }
        public int? EscuelaModelsId { get; set; }
        public int? CalendarioModelsId { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
        public string Usuario { get; set; }
    }
}
