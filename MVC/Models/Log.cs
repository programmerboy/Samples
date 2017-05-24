using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.Models
{
    public class Log : Common
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public string TransactionType { get; set; }
        public string Details { get; set; }

        //Navigation Properties
        public virtual Item Item { get; set; }
    }
}