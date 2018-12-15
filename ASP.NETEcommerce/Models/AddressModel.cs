using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NETEcommerce.Models
{
    public class AddressModel
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(120)]
        public string Detail { get; set; }
        [MaxLength(30)]
        public string District { get; set; }
        [MaxLength(30)]
        public string Subdistrict { get; set; }
        [MaxLength(30)]
        public string Province { get; set; }
        [MaxLength(5)]
        public string Postcode { get; set; }
    }
}