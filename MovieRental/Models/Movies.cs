using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Movies
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime RelaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number of Stock")]
        [Range(1, 20, ErrorMessage = "The field number in Stock must be between 1 and 20")]
        public int NoOfStock { get; set; }
    }
}