using System;
using System.Collections.Generic;

namespace Webtravel.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryPost = new HashSet<CategoryPost>();
        }

        public int IdCategory { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<CategoryPost> CategoryPost { get; set; }
    }
}
