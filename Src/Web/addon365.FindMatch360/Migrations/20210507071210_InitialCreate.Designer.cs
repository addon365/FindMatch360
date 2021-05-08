﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using addon365.FindMatch360.Data;

namespace addon365.FindMatch360.Migrations
{
    [DbContext(typeof(ilamaiMatrimonyContext))]
    [Migration("20210507071210_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("addon365.FindMatch360.Models.MatrimonyProfile", b =>
                {
                    b.Property<int>("MatrimonyProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("BirthNumberinFamily")
                        .HasColumnType("smallint");

                    b.Property<short>("Brothers")
                        .HasColumnType("smallint");

                    b.Property<bool>("ChevvaiDosham")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateandTimeOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExpectedQualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherQualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Height")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobPosition")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lagnam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("MarriedBrothers")
                        .HasColumnType("smallint");

                    b.Property<short>("MarriedSisters")
                        .HasColumnType("smallint");

                    b.Property<string>("MobileNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MonthlyRevenue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherJob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotherQualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nakshatra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NativeDistrict")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Sisters")
                        .HasColumnType("smallint");

                    b.HasKey("MatrimonyProfileId");

                    b.ToTable("MatrimonyProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}