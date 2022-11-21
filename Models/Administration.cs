using System.ComponentModel.DataAnnotations;

namespace ufrSet.Models
{
    public class Administration
    {

        [Key]
        public string matricule { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Profession { get; set; }


    }
}
