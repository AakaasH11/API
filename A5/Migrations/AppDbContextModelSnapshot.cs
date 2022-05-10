﻿// <auto-generated />
using System;
using A5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace A5.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("A5.Models.Award", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<int>("AwardTypeId")
                        .HasColumnType("int");

                    b.Property<int>("AwardeeId")
                        .HasColumnType("int");

                    b.Property<string>("CouponCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HRId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RejectedReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequesterId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AwardTypeId");

                    b.HasIndex("AwardeeId");

                    b.HasIndex("StatusId");

                    b.ToTable("Awards");
                });

            modelBuilder.Entity("A5.Models.AwardType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("AwardDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AwardName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AwardTypes");
                });

            modelBuilder.Entity("A5.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AwardId")
                        .HasColumnType("int");

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwardId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("A5.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrganisationId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("A5.Models.Designation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("DesignationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Designations");
                });

            modelBuilder.Entity("A5.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ACEID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DesignationId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HRId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganisationId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ReportingPersonId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("HRId");

                    b.HasIndex("OrganisationId");

                    b.HasIndex("ReportingPersonId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("A5.Models.Organisation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("AddedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("OrganisationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Organisations");
                });

            modelBuilder.Entity("A5.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("A5.Models.Award", b =>
                {
                    b.HasOne("A5.Models.AwardType", "AwardType")
                        .WithMany()
                        .HasForeignKey("AwardTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("A5.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("AwardeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("A5.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwardType");

                    b.Navigation("Employee");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("A5.Models.Comment", b =>
                {
                    b.HasOne("A5.Models.Award", "Award")
                        .WithMany()
                        .HasForeignKey("AwardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Award");
                });

            modelBuilder.Entity("A5.Models.Department", b =>
                {
                    b.HasOne("A5.Models.Organisation", null)
                        .WithMany("Departments")
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("A5.Models.Designation", b =>
                {
                    b.HasOne("A5.Models.Department", null)
                        .WithMany("Designations")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("A5.Models.Employee", b =>
                {
                    b.HasOne("A5.Models.Employee", "HR")
                        .WithMany("Hrs")
                        .HasForeignKey("HRId");

                    b.HasOne("A5.Models.Organisation", "Organisation")
                        .WithMany()
                        .HasForeignKey("OrganisationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("A5.Models.Employee", "ReportingPerson")
                        .WithMany("Reportingpersons")
                        .HasForeignKey("ReportingPersonId");

                    b.Navigation("HR");

                    b.Navigation("Organisation");

                    b.Navigation("ReportingPerson");
                });

            modelBuilder.Entity("A5.Models.Department", b =>
                {
                    b.Navigation("Designations");
                });

            modelBuilder.Entity("A5.Models.Employee", b =>
                {
                    b.Navigation("Hrs");

                    b.Navigation("Reportingpersons");
                });

            modelBuilder.Entity("A5.Models.Organisation", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
