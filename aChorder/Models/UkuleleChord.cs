using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aChorder.Models
{
    public class UkuleleChord: Chord
    {
        private List<int> Frets;
        string ImageName;

        protected UkuleleChord()
        {

        }

        public UkuleleChord(List<int> frets, string imageName)
        {
            Frets = frets;
            ImageName = imageName;
        }
    }
}
