using System;
using System.ComponentModel.DataAnnotations;


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
    }
}
