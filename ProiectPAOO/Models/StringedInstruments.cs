using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectPAOO.Models
{
    internal class StringedInstruments
    {
        public int InstrumentId { get; set; }
        public int NumberOfStrings { get; set; }
        public string Type { get; set; }
        public int Scale { get; set; }
        public int Frets { get; set; }
        public string Wood { get; set; }
    }
}
