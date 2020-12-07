using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Club
    {
        [Key]
        public string ClubID { get; set; }
        [StringLength(100)]
        public string ClubName { get; set; }
        [StringLength(100)]
        public string ClubColour { get; set; }
        [StringLength(100)]
        public string ClubCity { get; set; }
        public int ClubFounded { get; set; }
        [StringLength(100)]
        public string Stadium { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public Club()
        {
            Players = new List<Player>();
        }
    }
}