using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatalogApp.Models
{
    public class Item : Common
    {
        public int ID { get; set; }

        [Required, StringLength(50, MinimumLength = 1, ErrorMessage = "Name Field cannot be more than 50 characters")]
        public string Name { get; set; }

        [Required, StringLength(200, MinimumLength = 1, ErrorMessage = "Description Field cannot be more than 200 characters")]
        public string Description { get; set; }

        public virtual ICollection<ItemAttribute> ItemAttributes { get; set; }
        public virtual ICollection<ItemAttributeValue> ItemAttributeValues { get; set; }
    }
}