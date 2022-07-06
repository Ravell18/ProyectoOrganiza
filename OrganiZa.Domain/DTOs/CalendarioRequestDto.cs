using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiZa.Domain.DTOs
{
    public class CalendarioRequestDto
    {
        public int Id { get; set; }

        public string MesPago { get; set; }
        public string ModoP { get; set; }
        public double Colegiatura { get; set; }
        public string Statusdepago { get; set; }
        public string Alumno { get; set; }
        public int IdE { get; set; }
        public int IdP { get; set; }
        public int IdT { get; set; }
        public int IdA { get; set; }

        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
