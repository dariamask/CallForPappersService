﻿// <auto-generated />
using System;
using CallForPappersService_DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CallForPappersService_DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240415060823_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CallForPappersService_DAL.Data.Entities.Activity", b =>
                {
                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Type");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Type = 0,
                            Description = "Доклад, 35-45 минут"
                        },
                        new
                        {
                            Type = 2,
                            Description = "Дискуссия / круглый стол, 40-50 минут"
                        },
                        new
                        {
                            Type = 1,
                            Description = "Мастеркласс, 1-2 часа"
                        });
                });

            modelBuilder.Entity("CallForPappersService_DAL.Data.Entities.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("ActivityType")
                        .HasColumnType("integer");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Outline")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("SubmitDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ActivityType");

                    b.HasIndex("AuthorId");

                    b.HasIndex("Status");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("CallForPappersService_DAL.Data.Entities.Application", b =>
                {
                    b.HasOne("CallForPappersService_DAL.Data.Entities.Activity", "Activity")
                        .WithMany("Applications")
                        .HasForeignKey("ActivityType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("CallForPappersService_DAL.Data.Entities.Activity", b =>
                {
                    b.Navigation("Applications");
                });
#pragma warning restore 612, 618
        }
    }
}
