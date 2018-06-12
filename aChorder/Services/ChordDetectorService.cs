using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aChorder.Models;
using System.Text.RegularExpressions;

namespace aChorder.Services
{
    public class ChordDetectorService : IChordDetectorService
    {
        private IChordRepository chordRepository;

        public ChordDetectorService()
        {
            chordRepository = new MockChordRepository();
        }

        public ChordDetectorService(string alternateChordPath)
        {
            chordRepository = new MockChordRepository(alternateChordPath);
        }
        //Wstawić metode która sama ustali boczne lub górne

        public IEnumerable<string> ExtractTopChords(string songText)
        {
            List<string> _detectedChords = new List<string>();

            foreach(var line in this.CutIntoLines(songText))
            {
                if (Regex.Replace(line, @"\s+", " ").Split(' ').All(chordName => chordRepository.GetAllChords().Contains(chordName) || chordRepository.GetAllChords().Contains(chordName.ToUpper()+"m")))
                {
                    foreach (var chordName in Regex.Replace(line, @"\s+", " ").Split(' '))
                    {
                        if (chordName.Length == 1 && Char.IsLower(Convert.ToChar(chordName)))
                        {
                            _detectedChords.Add(chordName.ToUpper() + "m");
                        }
                        else
                        {
                            _detectedChords.Add(chordName);
                        }
                    }
                }
            }

            return _detectedChords.Distinct();
        }

        public IEnumerable<string> ExtractRightChords(string songText)
        {
            throw new NotFiniteNumberException();
        }

        public IEnumerable<String> CutIntoLines(string multipleLineText)
        {
            List<String> resultStringList = new List<string>();

            foreach (string line in multipleLineText.Split("\r\n"))
            {
                resultStringList.Add(line);
            }

            return resultStringList;
        }
    }
}
