using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather.Web.Models
{
    public class Parameters
    {
        [Key]
        public int RolID { get; set; }
        public string CodParam { get; set; }
        public string Value1 { get; set; }
        public string Description { get; set; }
    }
}