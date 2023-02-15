using System.ComponentModel.DataAnnotations;

namespace moment4.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string? Artist { get; set; }
        public string? Title { get; set; }
        public int Length { get; set; }

        // Relationship with category
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        // Relationship with song
        public List<Song>? Song { get; set; }
    }
}
