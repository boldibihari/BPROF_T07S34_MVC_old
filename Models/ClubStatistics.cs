using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ClubStatistics
    {
        public double ClubValue { get; set; }
        public int AverageAge { get; set; }
        public double AveragePlayerValue { get; set; }
        public List<string> Nationality { get; set; }
        public List<string> Position { get; set; }
    }
}
