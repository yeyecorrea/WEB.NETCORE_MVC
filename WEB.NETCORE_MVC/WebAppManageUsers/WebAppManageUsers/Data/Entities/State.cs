using System.ComponentModel.DataAnnotations;

namespace WebAppManageUsers.Data.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name = "Departamento/Estado")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public Country Country { get; set; }

        public ICollection<City> Cities  { get; set; }

        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
