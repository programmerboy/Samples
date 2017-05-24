using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CatalogApp.Models
{
    public class ItemAttributeValue : Common
    {
        [Key, Column(Order = 1)]
        public int ID { get; set; }
        
        public int RecordID { get; set; }
        public string Value { get; set; }

        //Foreign keys
        [Column(Order=2)]
        public int? ItemId { get; set; }
        [Column(Order = 3)]
        public int? ItemAttributeId { get; set; }

        public virtual Item Item { get; set; }
        public virtual ItemAttribute ItemAttribute { get; set; }
    }
}