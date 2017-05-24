using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatalogApp.Models
{
    public enum ItemDataType
    {
        Boolean,
        Date,
        [Display(Name = "IP Address")]
        IPAddress,
        Link,
        List,
        Number,
        Text
    }
}