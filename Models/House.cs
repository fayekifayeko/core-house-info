using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace House_Information.Models
{
    public class House
    {
        [Key]
        public string HouseID { get; set; }
        public string HouseName { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
