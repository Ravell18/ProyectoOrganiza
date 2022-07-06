using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OrganiZa.Domain.Entities;

#nullable disable

namespace OrganiZa.Domain.Entities
{
    public partial class User : BaseEntity
    {
   
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Please Provide A Value For First Name")]
        public string Contraseña { get; set; }
        [Required(ErrorMessage = "Please Provide A Value For First Name")]
        public string Rolusuario { get; set; }
        [Required(ErrorMessage = "Please Provide A Value For First Name")]
        public int IdT { get; set; }
        [Required(ErrorMessage = "Please Provide A Value For First Name")]
        public int IdA { get; set; }
        [Required(ErrorMessage = "Please Provide A Value For First Name")]
        public virtual ICollection<Administrador> Administradors { get; set; }
        public virtual ICollection<Tutor> Tutors { get; set; }

    }
}
