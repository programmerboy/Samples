using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }

        public ICollection<ItemAttribute> ItemAttributes { get; set; }
    }
}