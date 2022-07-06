using System;
using System.Collections.Generic;
using System.Text;

namespace OrganiZa.Domain.DTOs
{
    public class PagoResponseDto
    {
        public int Id { get; set; }

        public string Alumno { get; set; }
        public string Fichapago { get; set; }
        public string NombreT { get; set; }
        public DateTime Fecha { get; set; }
        public double Colegiatura { get; set; }
        public string Mespagado { get; set; }
        public byte[] Voucher { get; set; }
        public int TutorId { get; set; }
        public int IdE { get; set; }
        public string Statusdepago { get; set; }

        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdatedBy { get; set; }

    }
}
