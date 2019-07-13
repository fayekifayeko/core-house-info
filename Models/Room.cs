using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace House_Information.Models
{
    public class Room
    {
        public int RoomID { get; set; }
        public string HouseID { get; set; }
        public string Name { get; set; }
        public float Temprature { get; set; }
        public float Humidity { get; set; }
        public virtual House House { get; set; }
    }
}
