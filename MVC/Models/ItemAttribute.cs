using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CatalogApp.Models
{
    public class ItemAttribute : Common
    {
        public int ID { get; set; }
        public int ItemId { get; set; }

        [Required, StringLength(50, MinimumLength = 1, ErrorMessage = "Name Field cannot be more than 50 characters")]
        public string Name { get; set; }

        [Required, StringLength(200, MinimumLength = 1, ErrorMessage = "Description Field cannot be more than 200 characters")]
        public string Description { get; set; }

        [Required, Range(1, 50, ErrorMessage = "Should be between 1 and 50")]
        public int DisplayOrder { get; set; }

        public bool IsDisplayed { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsNullable { get; set; }
        public bool IsUnique { get; set; }
        public bool IsFixed { get; set; }

        public string DefaultValue { get; set; }

        public ItemDataType Type { get; set; }

        //Navigation Properties
        public virtual Item Item { get; set; }
        public virtual ICollection<ItemAttributeValue> ItemAttributeValues { get; set; }
    }
}