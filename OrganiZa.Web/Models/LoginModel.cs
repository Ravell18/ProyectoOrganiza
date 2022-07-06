using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class LoginModel
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rolusuario { get; set; }
        public int IdT { get; set; }
        public int IdA { get; set; }
        public bool status { get; set; }
    }
}
