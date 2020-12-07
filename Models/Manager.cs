using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class Manager
    {
        [Key]
        public string ManagerID { get; set; }
        [StringLength(100)]
        public string ManagerName { get; set; }
        [StringLength(100)]
        public string ManagerNationality { get; set; }
        public DateTime ManagerBirthDate { get; set; }
        public int ManagerStartYear { get; set; }
        [ForeignKey(nameof(Club))]
        public string ClubID { get; set; }
        [NotMapped]
        public virtual Club Club { get; set; }
    }
}