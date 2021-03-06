﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RentalManagementApps.Data;
using System;

namespace RentalManagementApps.Migrations
{
    [DbContext(typeof(RentalContext))]
    partial class RentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentalManagementApps.Models.Kost", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KostName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Kost");
                });

            modelBuilder.Entity("RentalManagementApps.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsNowAvailable");

                    b.Property<int>("KostID");

                    b.Property<int>("MonthlyFee");

                    b.Property<int>("RoomLength");

                    b.Property<string>("RoomName")
                        .IsRequired();

                    b.Property<int>("RoomWidth");

                    b.HasKey("ID");

                    b.HasIndex("KostID");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("RentalManagementApps.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConfirmPassword");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LastName")
                        .HasMaxLength(20);

                    b.Property<string>("NewPassword")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("ID");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("RentalManagementApps.Models.Room", b =>
                {
                    b.HasOne("RentalManagementApps.Models.Kost", "Kost")
                        .WithMany("Rooms")
                        .HasForeignKey("KostID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
