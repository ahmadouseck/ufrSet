using System.ComponentModel.DataAnnotations;

namespace ufrSet.Models
{
    public class Ufr
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Departement> departements { get; set; }
    }
}
