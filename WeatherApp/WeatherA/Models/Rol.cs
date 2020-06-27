using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }

        [Display(Name = "Rol")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(256, ErrorMessage = "El campo {0} debe tener entre {2} y {1}", MinimumLength = 3)]
        [Index("Rol_RolID_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}