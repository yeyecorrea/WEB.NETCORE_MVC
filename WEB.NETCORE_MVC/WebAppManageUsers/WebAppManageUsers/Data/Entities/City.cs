using System.ComponentModel.DataAnnotations;

namespace WebAppManageUsers.Data.Entities
{
    public class City
    {
        public int Id { get; set; }

        [Display(Name = "Ciudad")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public State State { get; set; }

        public ICollection<Client> Client { get; set; }

        [Display(Name = "Clientes")]
        public int ClientNumber => Client == null ? 0 : Client.Count;
    }
}
