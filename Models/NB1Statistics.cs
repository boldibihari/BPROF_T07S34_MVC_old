using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class NB1Statistics
    {
        public double ClubValue { get; set; }
        public int AverageAge { get; set; }
        public double AveragePlayerValue { get; set; }
        public double AverageClubValue { get; set; }
        public List<string> Nationality { get; set; }
        public List<string> Position { get; set; }
    }
}