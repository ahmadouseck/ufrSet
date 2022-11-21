using System.ComponentModel.DataAnnotations;

namespace ufrSet.Models
{
    public class Filiere
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
