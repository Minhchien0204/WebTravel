using System;
using System.Collections.Generic;

namespace Webtravel.Models
{
    public partial class CategoryPost
    {
        public int IdPost { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual Post IdPostNavigation { get; set; }
    }
}
