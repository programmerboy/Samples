using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.Models
{
    public class Common
    {
        public DateTime LastModified { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
    }
}