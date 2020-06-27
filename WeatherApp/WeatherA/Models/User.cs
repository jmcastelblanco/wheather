using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeatherA.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar una {0}")]
        [Display(Name = "DocumentType", Prompt = "[Seleccione una tipo de Documento]")]
        public int DocumentTypeID { get; set; }

        [Display(Name = "Número de Documento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(256, ErrorMessage = "El campo {0} debe tener entre {2} y {1}", MinimumLength = 3)]
        public string DocumentNumber { get; set; }

        [Display(Name = "Nombre de Usuario")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(256, ErrorMessage = "El campo {0} debe tener entre {2} y {1}", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [Index("User_UserName_Index",IsUnique = true)]
        public string UserName { get; set; }

        [Display(Name = "Primer Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(256, ErrorMessage = "El campo {0} debe tener entre {2} y {1}", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Segundo Nombre")]
        public string SecondName { get; set; }

        [Display(Name = "Primer Apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(256, ErrorMessage = "El campo {0} debe tener entre {2} y {1}", MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Segundo Apellido")]
        public string SecondLastName { get; set; }
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar una {0}")]
        [Display(Name = "Rol")]
        public int RolID { get; set; }

        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(30, ErrorMessage = "El campo {0} debe tener entre {2} y {1}", MinimumLength = 3)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(256, ErrorMessage = "El campo {0} debe tener entre {2} y {1}", MinimumLength = 3)]
        public string Address { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }

        [Display(Name = "País")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        public int CountryID { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar una {0}")]
        [Display(Name = "Ciudad")]
        public int CityID { get; set; }

        [Display(Name = "Usuario")]
        public string FullName { get { return string.Format("{0} {1} {2} {3} ", FirstName, SecondName, LastName, SecondLastName); } }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }
        public virtual ICollection<Session_log> Session_logs { get; set; }
    }
}