using System;
using System.Collections.Generic;

namespace Webtravel.Models
{
    public partial class Users
    {
        public Users()
        {
            Dattruoc = new HashSet<Dattruoc>();
            Post = new HashSet<Post>();
        }

        public int IdUser { get; set; }
        public string UserNames { get; set; }
        public string Passwords { get; set; }
        public string Phone { get; set; }
        public string Diachi { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Roles { get; set; }
        public bool? Gioitinh { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Dattruoc> Dattruoc { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
