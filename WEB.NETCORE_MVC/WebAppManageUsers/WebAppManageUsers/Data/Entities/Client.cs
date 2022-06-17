using System.ComponentModel.DataAnnotations;

namespace WebAppManageUsers.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Cedula")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nit { get; set; }

        [Display(Name = "Telefono/Celular")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Telephone { get; set; }

        [Display(Name = "Direccion")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Address { get; set; }

        public City City { get; set; }


    }
}
