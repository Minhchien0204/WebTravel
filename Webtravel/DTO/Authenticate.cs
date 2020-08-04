using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webtravel.Models
{
    public class Authenticate
    {
        /* [Required]
         public string Username { get; set; }

         [Required]
         public string Password { get; set; }*/
        public int IdUser { get; set; }
        public string UserNames { get; set; }
        public string Passwords { get; set; }
        public string Phone { get; set; }
        public string Diachi { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Roles { get; set; }
        public bool? Gioitinh { get; set; }
        public string Token { get; set; }
    }
}
