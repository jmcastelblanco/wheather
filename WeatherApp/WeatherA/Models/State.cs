using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener entre {2} y {1}", MinimumLength = 3)]
        [Index("State_Name_Index", IsUnique = true)]
        [Display(Name = "Estado")]
        public string Name { get; set; }
    }
}