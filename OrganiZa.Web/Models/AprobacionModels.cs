using OrganiZa.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganiZa.Web.Models
{
    public class AprobacionModels
    {
        public PagoRequestDto pagos { get; set; }
        public int Id { get; set; }
        public string Rolusuario { get; set; }
        public string Usuario { get; set; }
        public string ImageSource(byte[] yourImageBytes)
        {
            string mimeType = ("image/png");
            string base64 = Convert.ToBase64String(yourImageBytes);
            return string.Format("data:{0};base64,{1}", mimeType, base64);

        }
    }
}
