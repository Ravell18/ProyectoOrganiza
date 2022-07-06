using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrganiZa.Domain.Entities;


namespace OrganiZa.Web.Models
{
    public class HomeModel : PageModel
    {
        public int id { get; set; }
        public string Rolusuario { get; set; }
        public string Usuario { get; set; }




    }
}
