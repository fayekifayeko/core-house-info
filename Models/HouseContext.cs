using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace House_Information.Models
{
    public class HouseContext : DbContext
    {
        public HouseContext(DbContextOptions<HouseContext> options) : base(options)
        {

        }
        public DbSet<House> Houses { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
