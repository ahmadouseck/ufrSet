using System.ComponentModel.DataAnnotations;

namespace ufrSet.Models
{
    public class Departement
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public ICollection<Filiere> filieres { get; set; }
    }
}
