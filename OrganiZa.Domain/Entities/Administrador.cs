using OrganiZa.Domain.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace OrganiZa.Domain.Entities
{
    public partial class Administrador : BaseEntity
    {
        public string Rolusuario { get; set; }
        public string NombreAd { get; set; }
        public int? UsersId { get; set; }
        public int? EscuelaModelsId { get; set; }
        public int? CalendarioModelsId { get; set; }

        public virtual Calendario CalendarioModels { get; set; }
        public virtual Escuela EscuelaModels { get; set; }
        public virtual User Users { get; set; }
    }
}
