﻿// <auto-generated />
using System;
using ActiveDiabetesAssistant.DAL.SQL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ActiveDiabetesAssistant.DAL.SQL.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20240512131121_GlucoseInfo")]
    partial class GlucoseInfo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ActiveDiabetesAssistant.DAL.Entities.GlucoseInfoDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GlucoseData")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PersonInfoId")
                        .HasColumnType("uuid");

                    b.Property<int?>("StepsCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonInfoId");

                    b.ToTable("GlucoseInfoDto");
                });

            modelBuilder.Entity("ActiveDiabetesAssistant.DAL.Entities.PersonInfoDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DiabetesType")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Sex")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PersonInfoDto");
                });

            modelBuilder.Entity("ActiveDiabetesAssistant.DAL.Entities.UserDto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("TokenExpiredAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ActiveDiabetesAssistant.DAL.Entities.GlucoseInfoDto", b =>
                {
                    b.HasOne("ActiveDiabetesAssistant.DAL.Entities.PersonInfoDto", "PersonInfo")
                        .WithMany("GlucoseInfos")
                        .HasForeignKey("PersonInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInfo");
                });

            modelBuilder.Entity("ActiveDiabetesAssistant.DAL.Entities.PersonInfoDto", b =>
                {
                    b.HasOne("ActiveDiabetesAssistant.DAL.Entities.UserDto", "User")
                        .WithOne("PersonInfo")
                        .HasForeignKey("ActiveDiabetesAssistant.DAL.Entities.PersonInfoDto", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ActiveDiabetesAssistant.DAL.Entities.PersonInfoDto", b =>
                {
                    b.Navigation("GlucoseInfos");
                });

            modelBuilder.Entity("ActiveDiabetesAssistant.DAL.Entities.UserDto", b =>
                {
                    b.Navigation("PersonInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
