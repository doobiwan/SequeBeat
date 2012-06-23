using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequeBeat.Model
{
    class Sequence
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int Bpm { get; set; }
        public IList<Measure> Measures { get; set; }
    }
}
