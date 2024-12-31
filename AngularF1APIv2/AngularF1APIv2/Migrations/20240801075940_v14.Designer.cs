﻿// <auto-generated />
using System;
using AngularF1APIv2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AngularF1APIv2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240801075940_v14")]
    partial class v14
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AngularF1APIv2.Models.Driver", b =>
                {
                    b.Property<int>("DriverID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DriverID"));

                    b.Property<string>("DriverDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DriverName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverNumber")
                        .HasColumnType("int");

                    b.Property<int>("DriverPoints")
                        .HasColumnType("int");

                    b.Property<int>("DriverPosition")
                        .HasColumnType("int");

                    b.Property<string>("Driver_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DriverID");

                    b.HasIndex("TeamID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("AngularF1APIv2.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostID"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FavoriteTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("AngularF1APIv2.Models.Schedule", b =>
                {
                    b.Property<int>("RaceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RaceID"));

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RaceDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race_Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RaceID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("AngularF1APIv2.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"));

                    b.Property<string>("Car_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamDrivers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeamName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamPoints")
                        .HasColumnType("int");

                    b.Property<int>("TeamPosition")
                        .HasColumnType("int");

                    b.HasKey("TeamID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("AngularF1APIv2.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FavoriteTeam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("AngularF1APIv2.Models.Driver", b =>
                {
                    b.HasOne("AngularF1APIv2.Models.Team", "Team")
                        .WithMany("Drivers")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("AngularF1APIv2.Models.Post", b =>
                {
                    b.HasOne("AngularF1APIv2.Models.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AngularF1APIv2.Models.Team", b =>
                {
                    b.Navigation("Drivers");
                });

            modelBuilder.Entity("AngularF1APIv2.Models.User", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
