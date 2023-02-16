using System.ComponentModel.DataAnnotations;

namespace moment4.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Du måste ange artistens namn")]
        public string? Artist { get; set; }

        [Display(Name = "Titel")]
        [Required(ErrorMessage = "Du måste ange titel på låten")]
        public string? Title { get; set; }

        [Display(Name = "Längd [sekunder]")]
        [Required(ErrorMessage = "Du måste ange låtens längd i sekunder")]
        public int Length { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Du måste ange vilken kategori låten tillhör")]
        public string? Category { get; set; }
    }
}
