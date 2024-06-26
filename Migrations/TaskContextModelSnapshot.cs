﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using projectEF;

#nullable disable

namespace projectEF.Migrations
{
    [DbContext(typeof(TaskContext))]
    partial class TaskContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("projectEF.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("989c5a75-4667-464b-b0da-9f63e7b0c1c7"),
                            Name = "Actividades pendientes",
                            Weight = 20
                        },
                        new
                        {
                            Id = new Guid("989c5a75-4667-464b-b0da-9f63e7b0c102"),
                            Name = "Actividades Personales",
                            Weight = 50
                        });
                });

            modelBuilder.Entity("projectEF.Models.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zonee");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("PriorityTask")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Task", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("989c5a75-4667-464b-b0da-9f63e7b0c110"),
                            CategoriaId = new Guid("989c5a75-4667-464b-b0da-9f63e7b0c1c7"),
                            CreateDate = new DateTime(2024, 5, 27, 23, 4, 22, 27, DateTimeKind.Utc).AddTicks(2279),
                            PriorityTask = 1,
                            Title = "Pago de servicios publicos"
                        },
                        new
                        {
                            Id = new Guid("989c5a75-4667-464b-b0da-9f63e7b0c111"),
                            CategoriaId = new Guid("989c5a75-4667-464b-b0da-9f63e7b0c102"),
                            CreateDate = new DateTime(2024, 5, 27, 23, 4, 22, 27, DateTimeKind.Utc).AddTicks(2344),
                            PriorityTask = 0,
                            Title = "Terminar de ver pelicula en Netflix"
                        });
                });

            modelBuilder.Entity("projectEF.Models.Task", b =>
                {
                    b.HasOne("projectEF.Models.Category", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("projectEF.Models.Category", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
