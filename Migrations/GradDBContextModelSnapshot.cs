﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SKC_MVC.Data;

#nullable disable

namespace SKC_MVC.Migrations
{
    [DbContext(typeof(GradDBContext))]
    partial class GradDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SKC_MVC.Models.ClSeSu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<bool>("Flag")
                        .HasColumnType("bit");

                    b.Property<int>("NumOfClassPerWeek")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("ClSeSus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            Flag = true,
                            NumOfClassPerWeek = 4
                        });
                });

            modelBuilder.Entity("SKC_MVC.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("NumberOfClassesPerWeek")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfStudents")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Classes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            NumberOfClassesPerWeek = 5,
                            NumberOfStudents = 30
                        });
                });

            modelBuilder.Entity("SKC_MVC.Models.Grades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Exam1")
                        .HasColumnType("int");

                    b.Property<int>("Exam2")
                        .HasColumnType("int");

                    b.Property<int>("FinalExam")
                        .HasColumnType("int");

                    b.Property<int>("Homeworks")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("TotalGrades")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Exam1 = 88,
                            Exam2 = 92,
                            FinalExam = 85,
                            Homeworks = 95,
                            StudentId = 1,
                            TotalGrades = 90
                        });
                });

            modelBuilder.Entity("SKC_MVC.Models.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassId = 1,
                            Count = 25
                        });
                });

            modelBuilder.Entity("SKC_MVC.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Class = "Some Class",
                            Name = "John Doe",
                            Section = "A"
                        });
                });

            modelBuilder.Entity("SKC_MVC.Models.ClSeSu", b =>
                {
                    b.HasOne("SKC_MVC.Models.Class", "Class")
                        .WithMany("ClSeSu")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("SKC_MVC.Models.Grades", b =>
                {
                    b.HasOne("SKC_MVC.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SKC_MVC.Models.Section", b =>
                {
                    b.HasOne("SKC_MVC.Models.Class", "Class")
                        .WithMany("Sections")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");
                });

            modelBuilder.Entity("SKC_MVC.Models.Student", b =>
                {
                    b.HasOne("SKC_MVC.Models.Section", null)
                        .WithMany("Students")
                        .HasForeignKey("SectionId");
                });

            modelBuilder.Entity("SKC_MVC.Models.Class", b =>
                {
                    b.Navigation("ClSeSu");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("SKC_MVC.Models.Section", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("SKC_MVC.Models.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
