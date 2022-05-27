using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCatalogue.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieCatalogue.Domain.DTO
{
    public class MovieDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string Link { get; set; }

        [Display(Name = "Genres")]
        public List<Guid> GenreIds { get; set; }

        public MultiSelectList GenresSelectList { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
