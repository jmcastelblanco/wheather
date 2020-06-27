using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class Session_log
    {
        public int Session_logID { get; set; }
        public int UserID { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Boolean Entry { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }
        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }
        public string Commentaries { get; set; }

        public virtual User User { get; set; }
    }
}