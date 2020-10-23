﻿// <auto-generated />
using System;
using EmployeeAppApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeAppApi.Migrations
{
    [DbContext(typeof(EmployeeAppContext))]
    [Migration("20201022185630_1st migration - creating the db")]
    partial class _1stmigrationcreatingthedb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeAppApi.Models.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = "66774006-2371-4d5b-8518-2177bcf3f73e",
                            Name = "HR"
                        },
                        new
                        {
                            Id = "24fd81f8-d58a-4bcc-9f35-dc6cd5641906",
                            Name = "IT"
                        },
                        new
                        {
                            Id = "261e1685-cf26-494c-b17c-3546e65f5620",
                            Name = "Payroll"
                        });
                });

            modelBuilder.Entity("EmployeeAppApi.Models.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfJoining")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(80)")
                        .HasMaxLength(80);

                    b.Property<string>("PhotoFileName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = "a3c1880c-674c-4d18-8f91-5d3608a2c937",
                            DateOfJoining = new DateTime(2020, 10, 22, 20, 56, 29, 665, DateTimeKind.Local).AddTicks(9412),
                            DepartmentId = "24fd81f8-d58a-4bcc-9f35-dc6cd5641906",
                            Name = "youssef nabet"
                        },
                        new
                        {
                            Id = "f98e4d74-0f68-4aac-89fd-047f1aaca6b6",
                            DateOfJoining = new DateTime(2020, 10, 22, 20, 56, 29, 668, DateTimeKind.Local).AddTicks(1645),
                            DepartmentId = "261e1685-cf26-494c-b17c-3546e65f5620",
                            Name = "Aaron Baetens"
                        },
                        new
                        {
                            Id = "0f8fad5b-d9cb-469f-a165-70867728950e",
                            DateOfJoining = new DateTime(2020, 10, 22, 20, 56, 29, 668, DateTimeKind.Local).AddTicks(1680),
                            DepartmentId = "261e1685-cf26-494c-b17c-3546e65f5620",
                            Name = "Vincent Nys"
                        });
                });

            modelBuilder.Entity("EmployeeAppApi.Models.Employee", b =>
                {
                    b.HasOne("EmployeeAppApi.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
