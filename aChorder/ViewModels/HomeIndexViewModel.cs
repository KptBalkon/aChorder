using aChorder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aChorder.ViewModels
{
    public class HomeIndexViewModel
    {
        public Song song { get; set; }
        public IEnumerable<string> detectedChords { get; set; }
    }
}
