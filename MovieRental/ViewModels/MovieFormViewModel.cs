using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRental.ViewModels
{
    public class MovieFormViewModel
    {
        public Movies Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}