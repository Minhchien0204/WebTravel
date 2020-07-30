using System;
using System.Collections.Generic;

namespace Webtravel.Models
{
    public partial class Post
    {
        public Post()
        {
            CategoryPost = new HashSet<CategoryPost>();
        }

        public int IdPost { get; set; }
        public string Content { get; set; }
        public int? Danhgia { get; set; }
        public string Diachi { get; set; }
        public byte[] Img { get; set; }
        public int? IdUser { get; set; }
        public int? IdToado { get; set; }
        public int? IdHouse { get; set; }

        public virtual House IdHouseNavigation { get; set; }
        public virtual Toado IdToadoNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
        public virtual ICollection<CategoryPost> CategoryPost { get; set; }
    }
}
