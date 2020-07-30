using System;
using System.Collections.Generic;

namespace Webtravel.Models
{
    public partial class Toado
    {
        public Toado()
        {
            Post = new HashSet<Post>();
        }

        public int IdToado { get; set; }
        public double? Lags { get; set; }
        public double? Lng { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
