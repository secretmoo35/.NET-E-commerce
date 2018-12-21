using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETMVCEcommerce.Models
{
    public class ProductModel
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
    }
}