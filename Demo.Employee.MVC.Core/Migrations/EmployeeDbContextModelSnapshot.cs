﻿// <auto-generated />
using System;
using Demo.Employee.MVC.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Demo.Employee.MVC.Core.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Demo.Employee.MVC.Core.Infrastructure.EmployeeEntity", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int(11)");

                    b.Property<int>("JobProfileId")
                        .HasColumnType("int(11)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("PinCode")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<ulong>("Status")
                        .HasColumnType("bit(1)");

                    b.HasKey("EmployeeId");

                    b.ToTable("employee");
                });

            modelBuilder.Entity("Demo.Employee.MVC.Core.Infrastructure.JobProfileEntity", b =>
                {
                    b.Property<int>("JobProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)");

                    b.Property<string>("JobProfileName")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.HasKey("JobProfileId");

                    b.ToTable("jobprofile");

                    b.HasData(
                        new
                        {
                            JobProfileId = 1,
                            JobProfileName = "Director"
                        },
                        new
                        {
                            JobProfileId = 2,
                            JobProfileName = "Manager"
                        },
                        new
                        {
                            JobProfileId = 3,
                            JobProfileName = "Trainee"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}