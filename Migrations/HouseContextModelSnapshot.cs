﻿// <auto-generated />
using House_Information.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace House_Information.Migrations
{
    [DbContext(typeof(HouseContext))]
    partial class HouseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("House_Information.Models.House", b =>
                {
                    b.Property<string>("HouseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HouseName");

                    b.HasKey("HouseID");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("House_Information.Models.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HouseID");

                    b.Property<float>("Humidity");

                    b.Property<string>("Name");

                    b.Property<float>("Temprature");

                    b.HasKey("RoomID");

                    b.HasIndex("HouseID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("House_Information.Models.Room", b =>
                {
                    b.HasOne("House_Information.Models.House", "House")
                        .WithMany("Rooms")
                        .HasForeignKey("HouseID");
                });
#pragma warning restore 612, 618
        }
    }
}
