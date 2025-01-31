﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using quiLV_ALTA_Class.Data;

#nullable disable

namespace quiLV_ALTA_Class.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Calendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassRoom")
                        .HasColumnType("int");

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("Study_Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Subject_ID")
                        .HasColumnType("int");

                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Class_Id");

                    b.HasIndex("Subject_ID");

                    b.HasIndex("Teacher_Id");

                    b.ToTable("calendars");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Classes", b =>
                {
                    b.Property<int>("Class_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Class_Id"), 1L, 1);

                    b.Property<string>("Block")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number_Of_Students")
                        .HasColumnType("int");

                    b.Property<float>("School_Fee")
                        .HasColumnType("real");

                    b.Property<string>("School_Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.HasKey("Class_Id");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Course", b =>
                {
                    b.Property<int>("Course_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Course_ID"), 1L, 1);

                    b.Property<string>("Course_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Course_ID");

                    b.ToTable("courses");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Holiday_schedule", b =>
                {
                    b.Property<int>("Holiday_Schedule_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Holiday_Schedule_Id"), 1L, 1);

                    b.Property<string>("Holiday_Schedule_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time_End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Time_Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Holiday_Schedule_Id");

                    b.ToTable("holiday_Schedules");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Nest_Department", b =>
                {
                    b.Property<int>("Nest_Department_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Nest_Department_Id"), 1L, 1);

                    b.Property<string>("Nest_Department_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Nest_Department_Id");

                    b.ToTable("nest_Departments");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Point", b =>
                {
                    b.Property<int>("Point_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Point_ID"), 1L, 1);

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<int>("Point_Type_ID")
                        .HasColumnType("int");

                    b.Property<int>("Required_Points")
                        .HasColumnType("int");

                    b.Property<int>("Score_Column_Number")
                        .HasColumnType("int");

                    b.Property<int>("Subject_ID")
                        .HasColumnType("int");

                    b.HasKey("Point_ID");

                    b.HasIndex("Course_ID");

                    b.HasIndex("Point_Type_ID");

                    b.HasIndex("Subject_ID");

                    b.ToTable("points");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Point_Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<int>("Point_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Class_Id");

                    b.HasIndex("Point_ID");

                    b.ToTable("point_Classes");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Point_Type", b =>
                {
                    b.Property<int>("Point_Type_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Point_Type_ID"), 1L, 1);

                    b.Property<string>("Point_Type_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("coefficient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Point_Type_ID");

                    b.ToTable("point_types");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Revenue", b =>
                {
                    b.Property<int>("Revenue_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Revenue_Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Revenue_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Revenue_Id");

                    b.HasIndex("Class_Id");

                    b.ToTable("revenue");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Roles", b =>
                {
                    b.Property<int>("Role_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Role_Id"), 1L, 1);

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Role_Id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Student", b =>
                {
                    b.Property<int>("Student_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Student_Id"), 1L, 1);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<string>("Parent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Student_LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Student_Id");

                    b.HasIndex("User_ID");

                    b.ToTable("student");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Student_Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<int>("Student_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Class_Id");

                    b.HasIndex("Student_Id");

                    b.ToTable("student_Classes");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Subject", b =>
                {
                    b.Property<int>("Subject_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Subject_ID"), 1L, 1);

                    b.Property<int>("Nest_Department_Id")
                        .HasColumnType("int");

                    b.Property<string>("Subject_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Subject_ID");

                    b.HasIndex("Nest_Department_Id");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Subject_Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<int>("Subject_ID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Class_Id");

                    b.HasIndex("Subject_ID");

                    b.ToTable("subject_Classes");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Teacher", b =>
                {
                    b.Property<int>("Teacher_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Teacher_Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Concurrently")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Gender")
                        .HasColumnType("tinyint");

                    b.Property<int>("Nest_Department_Id")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tax_Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Teacher_Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("Teacher_FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher_LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Teacher_Id");

                    b.HasIndex("Nest_Department_Id");

                    b.ToTable("teacher");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Teacher_CLass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Class_Id");

                    b.HasIndex("Teacher_Id");

                    b.ToTable("teacher_CLasses");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.User", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("User_ID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role_ID")
                        .HasColumnType("int");

                    b.Property<string>("User_Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("User_ID");

                    b.HasIndex("Role_ID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Wage", b =>
                {
                    b.Property<int>("Wage_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Wage_ID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("Teacher_Id")
                        .HasColumnType("int");

                    b.Property<float>("Total_Salary")
                        .HasColumnType("real");

                    b.HasKey("Wage_ID");

                    b.HasIndex("Teacher_Id");

                    b.ToTable("wages");
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Calendar", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Classes", null)
                        .WithMany()
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("quiLV_ALTA_Class.Model.Subject", null)
                        .WithMany()
                        .HasForeignKey("Subject_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("quiLV_ALTA_Class.Model.Teacher", null)
                        .WithMany()
                        .HasForeignKey("Teacher_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Point", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Course", null)
                        .WithMany()
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("quiLV_ALTA_Class.Model.Point_Type", null)
                        .WithMany()
                        .HasForeignKey("Point_Type_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("quiLV_ALTA_Class.Model.Subject", null)
                        .WithMany()
                        .HasForeignKey("Subject_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Point_Class", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Classes", null)
                        .WithMany()
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("quiLV_ALTA_Class.Model.Point", null)
                        .WithMany()
                        .HasForeignKey("Point_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Revenue", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Classes", null)
                        .WithMany()
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Student", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.User", null)
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Student_Class", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Classes", null)
                        .WithMany()
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("quiLV_ALTA_Class.Model.Student", null)
                        .WithMany()
                        .HasForeignKey("Student_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Subject", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Nest_Department", null)
                        .WithMany()
                        .HasForeignKey("Nest_Department_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Subject_Class", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Classes", null)
                        .WithMany()
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("quiLV_ALTA_Class.Model.Subject", null)
                        .WithMany()
                        .HasForeignKey("Subject_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Teacher", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Nest_Department", null)
                        .WithMany()
                        .HasForeignKey("Nest_Department_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Teacher_CLass", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Classes", null)
                        .WithMany()
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("quiLV_ALTA_Class.Model.Teacher", null)
                        .WithMany()
                        .HasForeignKey("Teacher_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.User", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Roles", null)
                        .WithMany()
                        .HasForeignKey("Role_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("quiLV_ALTA_Class.Model.Wage", b =>
                {
                    b.HasOne("quiLV_ALTA_Class.Model.Teacher", null)
                        .WithMany()
                        .HasForeignKey("Teacher_Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
