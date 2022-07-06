using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiZa.Domain.DTOs
{
    public class UsuarioRequestDto
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rolusuario { get; set; }
        public int IdT { get; set; }
        public int IdA { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
