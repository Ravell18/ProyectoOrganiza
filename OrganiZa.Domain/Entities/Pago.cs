using System;
using System.Collections.Generic;
using OrganiZa.Domain.Entities;

#nullable disable

namespace OrganiZa.Domain.Entities
{
    public partial class Pago : BaseEntity
    {
        public Pago()
        {
            Escuelas = new HashSet<Escuela>();
            Tutors = new HashSet<Tutor>();
        }

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
        public int? CalendarioModelsId { get; set; }

        public virtual Calendario CalendarioModels { get; set; }
        public virtual ICollection<Escuela> Escuelas { get; set; }
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}
