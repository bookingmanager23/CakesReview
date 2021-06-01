using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CakesApi.Entities
{
    public class Cake
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Comment { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [Range(1,5)]
        public int YumFactor { get; set; }
    }
}
