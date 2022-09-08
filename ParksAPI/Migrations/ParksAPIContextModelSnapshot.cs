﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParksAPI.Models;

namespace ParksAPI.Migrations
{
    [DbContext(typeof(ParksAPIContext))]
    partial class ParksAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ParksAPI.Models.Park", b =>
                {
                    b.Property<int>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("State")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Type")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");

                    b.HasData(
                        new
                        {
                            ParkId = 1,
                            Name = "Yosemite",
                            State = "California",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 2,
                            Name = "Big Basin Redwoods",
                            State = "California",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 3,
                            Name = "Yellowstone",
                            State = "Montana",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 4,
                            Name = "Bridal Veil Falls",
                            State = "Oregon",
                            Type = "State"
                        },
                        new
                        {
                            ParkId = 5,
                            Name = "Crater Lake National Park",
                            State = "Oregon",
                            Type = "National"
                        },
                        new
                        {
                            ParkId = 6,
                            Name = "Lime Kiln Point",
                            State = "Washington",
                            Type = "State"
                        },
                        new
                        {
                            ParkId = 7,
                            Name = "Eagle Island Marine",
                            State = "Washington",
                            Type = "State"
                        },
                        new
                        {
                            ParkId = 8,
                            Name = "Otter Point",
                            State = "Oregon",
                            Type = "State"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
