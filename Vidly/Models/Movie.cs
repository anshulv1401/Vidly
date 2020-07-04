using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number in stock")]
        public byte NumberInStock { get; set; }

        [Range(1, 20)]
        [Display(Name = "Available in stock")]
        public byte NumberAvailable { get; set; }

    }
}
