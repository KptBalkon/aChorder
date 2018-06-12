using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace aChorder.Models
{
    public class Song
    {
        [Required, MaxLength(80)]
        public string Title { get; set; }

        public string Author { get; set; }

        [Required]
        public string SongText { get; set; }
    }
}
