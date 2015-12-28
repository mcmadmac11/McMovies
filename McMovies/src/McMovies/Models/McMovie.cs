using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace McMovies.Models
{
    public class McMovie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Cast { get; set; }
        public string RunTime { get; set; }
        public string Review { get; set; }
    }
}
