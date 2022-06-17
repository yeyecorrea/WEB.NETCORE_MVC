using System.ComponentModel.DataAnnotations;

namespace WebAppManageUsers.Data.Entities
{
    /// <summary>
    /// Se crea la entidad Country la cual va almacenar los paises
    /// </summary>
    public class Country
    {
        public int Id { get; set; }

        [Display(Name = "Pais")]
        [MaxLength(20, ErrorMessage ="El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage ="El campo {0} es obligatorio")]
        public string Name { get; set; }

        public ICollection<State> States { get; set; }

        [Display(Name = "Estados/Departamentos")]
        public int StatesNumber => States == null ? 0 : States.Count;
    }
}
