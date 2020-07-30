using System;
using System.Collections.Generic;

namespace Webtravel.Models
{
    public partial class House
    {
        public House()
        {
            HouseTienichs = new HashSet<HouseTienichs>();
            Post = new HashSet<Post>();
        }

        public int IdHouse { get; set; }
        public int? Sophong { get; set; }
        public int? Dientich { get; set; }
        public int? Songuoi { get; set; }
        public decimal? Gia { get; set; }
        public int IdPhong { get; set; }
        public int? Sogiuong { get; set; }
        public int? Songuoiphong { get; set; }
        public decimal? Giaphong { get; set; }
        public bool? Loai { get; set; }

        public virtual ICollection<HouseTienichs> HouseTienichs { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
