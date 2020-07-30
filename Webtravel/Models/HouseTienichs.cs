using System;
using System.Collections.Generic;

namespace Webtravel.Models
{
    public partial class HouseTienichs
    {
        public int IdTienichdetail { get; set; }
        public int IdHouse { get; set; }

        public virtual House IdHouseNavigation { get; set; }
    }
}
