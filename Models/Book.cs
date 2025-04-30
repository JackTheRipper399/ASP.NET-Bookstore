using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Author field is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, 9999.99, ErrorMessage = "The Price must be greater than 0.")]
        public decimal Price { get; set; }
    }
}
