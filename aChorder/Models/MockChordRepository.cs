using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace aChorder.Models
{
    public class MockChordRepository: IChordRepository
    {
        private List<string> _chords;
        private string path;

        public MockChordRepository()
        {
            this.path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Chords");
            if (_chords==null)
            {
                InitializeChords();
            }
        }

        public MockChordRepository(string path)
        {
            this.path = path;
            if (_chords == null)
            {
                InitializeChords();
            }
        }


        public IEnumerable<string> GetAllChords()
        {
            return _chords;
        }

        private void InitializeChords()
        {
            _chords = new List<string>();

            string[] chordNames = System.IO.Directory.GetFiles(path);

            for (int i = 0; i < chordNames.Count(); i++)
            {
                _chords.Add(chordNames[i].Replace(path + "\\", "").Replace(".png", ""));
            }
        }
    }
}
