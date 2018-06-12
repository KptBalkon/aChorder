using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aChorder.Models
{
    public class Chord
    {
        public string Name;

        protected Chord()
        {

        }

        public Chord(string name)
        {
            Name = name;
        }

    }
}
