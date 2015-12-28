using System;
using System.ComponentModel.DataAnnotations;
//http://docs.asp.net/projects/mvc/en/latest/getting-started/first-mvc-app/new-field.html#adding-a-new-field

namespace McMovies.Models
{
    public class McMovie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Cast { get; set; }
        public string RunTime { get; set; }
        public string Review { get; set; }
        public string Rating { get; set; }
    }
}
