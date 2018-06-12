using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aChorder.Models
{
    public interface IChordRepository
    {
        IEnumerable<string> GetAllChords();
    }
}
