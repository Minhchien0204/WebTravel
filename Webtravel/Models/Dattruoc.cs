using System;
using System.Collections.Generic;

namespace Webtravel.Models
{
    public partial class Dattruoc
    {
        public int IdDattruoc { get; set; }
        public DateTime? Ngaybatdau { get; set; }
        public DateTime? Ngayketthuc { get; set; }
        public bool? Trangthai { get; set; }
        public int? IdUser { get; set; }

        public virtual Users IdUserNavigation { get; set; }
    }
}
