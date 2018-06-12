using aChorder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aChorder.Services
{
    public interface IChordDetectorService
    {
        IEnumerable<string> ExtractRightChords(String songText);
        IEnumerable<string> ExtractTopChords(String songText);
        IEnumerable<String> CutIntoLines(string multipleLineText);
    }
}
