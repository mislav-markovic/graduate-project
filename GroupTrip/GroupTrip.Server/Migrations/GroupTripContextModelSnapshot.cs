﻿// <auto-generated />
using System;
using GroupTrip.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GroupTrip.Server.Migrations
{
    [DbContext(typeof(GroupTripContext))]
    partial class GroupTripContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GroupTrip.Shared.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("GroupDbSet");
                });

            modelBuilder.Entity("GroupTrip.Shared.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PersonId");

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("PaymentDbSet");
                });

            modelBuilder.Entity("GroupTrip.Shared.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<int>("GroupId");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("PersonDbSet");
                });

            modelBuilder.Entity("GroupTrip.Shared.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Location");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("TripDbSet");
                });

            modelBuilder.Entity("GroupTrip.Shared.Models.Group", b =>
                {
                    b.HasOne("GroupTrip.Shared.Models.Trip", "Trip")
                        .WithMany("Groups")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GroupTrip.Shared.Models.Payment", b =>
                {
                    b.HasOne("GroupTrip.Shared.Models.Person", "Person")
                        .WithMany("Payments")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GroupTrip.Shared.Models.Person", b =>
                {
                    b.HasOne("GroupTrip.Shared.Models.Group", "Group")
                        .WithMany("People")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}