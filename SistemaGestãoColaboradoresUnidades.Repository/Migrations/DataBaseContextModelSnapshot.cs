﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaGestãoColaboradoresUnidades.Repository;

#nullable disable

namespace SistemaGestãoColaboradoresUnidades.Repository.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaGestãoColaboradoresUnidades.Domain.Entity.CollaboratorEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("UnityEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UnityEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("CollaboratorEntity");
                });

            modelBuilder.Entity("SistemaGestãoColaboradoresUnidades.Domain.Entity.UnityEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("Code")
                        .HasColumnType("integer");

                    b.Property<bool>("Inactivated")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UnityEntity");
                });

            modelBuilder.Entity("SistemaGestãoColaboradoresUnidades.Domain.Entity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("UserEntity");
                });

            modelBuilder.Entity("SistemaGestãoColaboradoresUnidades.Domain.Entity.CollaboratorEntity", b =>
                {
                    b.HasOne("SistemaGestãoColaboradoresUnidades.Domain.Entity.UnityEntity", "UnityEntity")
                        .WithMany("CollectionCollaboratorEntity")
                        .HasForeignKey("UnityEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaGestãoColaboradoresUnidades.Domain.Entity.UserEntity", "UserEntity")
                        .WithMany("CollectionCollaboratorEntity")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UnityEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("SistemaGestãoColaboradoresUnidades.Domain.Entity.UnityEntity", b =>
                {
                    b.Navigation("CollectionCollaboratorEntity");
                });

            modelBuilder.Entity("SistemaGestãoColaboradoresUnidades.Domain.Entity.UserEntity", b =>
                {
                    b.Navigation("CollectionCollaboratorEntity");
                });
#pragma warning restore 612, 618
        }
    }
}
