using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequeBeat.Model
{
    class Measure
    {
        public double Gain { get; set; }
        public double PushPull { get; set; }
        public Sample Sample { get; set; }
        public IList<Note> Notes { get; set; }
    }
}
