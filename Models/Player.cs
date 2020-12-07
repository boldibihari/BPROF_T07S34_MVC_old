using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public enum PlayerPosition
    {
        Goalkeeper, Defender, Midfielder, Forward
    }
    public class Player
    {
        [Key]
        public string PlayerID { get; set; }
        [StringLength(100)]
        public string PlayerName { get; set; }
        [StringLength(100)]
        public string PlayerNationality { get; set; }
        public DateTime PlayerBirthDate { get; set; }
        public PlayerPosition PlayerPosition { get; set; }
        public double PlayerValue { get; set; }
        [ForeignKey(nameof(Club))]
        public string ClubID { get; set; }
        [NotMapped]
        public virtual Club Club { get; set; }
    }
}