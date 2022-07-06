using System;
using System.Collections.Generic;
using OrganiZa.Domain.Entities;

namespace OrganiZa.Domain.Entities
{
    public partial class Escuela :BaseEntity
    {
        public Escuela()
        {
            Administradors = new HashSet<Administrador>();
            Tutors = new HashSet<Tutor>();
        }

 
        public string NombreE { get; set; }
        public string NombreAd { get; set; }
        public string ModoP { get; set; }
        public int Nreferencia { get; set; }
        public double Colegiatura { get; set; }
        public int IdA { get; set; }
        public int? CalendarioModelsId { get; set; }
        public int? PagosModelsId { get; set; }

        public virtual Calendario CalendarioModels { get; set; }
        public virtual Pago PagosModels { get; set; }
        public virtual ICollection<Administrador> Administradors { get; set; }
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}
