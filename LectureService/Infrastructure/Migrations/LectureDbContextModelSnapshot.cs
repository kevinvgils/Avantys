﻿// <auto-generated />
using System;
using LectureService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LectureService.Infrastructure.Migrations
{
    [DbContext(typeof(LectureDbContext))]
    partial class LectureDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LectureService.Domain.Class", b =>
                {
                    b.Property<Guid>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("LectureService.Domain.Lecture", b =>
                {
                    b.Property<Guid>("LectureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClassId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StudyMaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LectureId");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudyMaterialId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("LectureService.Domain.StudyMaterial", b =>
                {
                    b.Property<Guid>("StudyMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudyMaterialId");

                    b.ToTable("StudyMaterials");
                });

            modelBuilder.Entity("LectureService.Domain.Lecture", b =>
                {
                    b.HasOne("LectureService.Domain.Class", "class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("LectureService.Domain.StudyMaterial", "StudyMaterial")
                        .WithMany()
                        .HasForeignKey("StudyMaterialId");

                    b.Navigation("StudyMaterial");

                    b.Navigation("class");
                });
#pragma warning restore 612, 618
        }
    }
}
