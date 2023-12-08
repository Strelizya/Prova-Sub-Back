﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROVAAPI;

#nullable disable

namespace PROVAAPI.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("PROVAAPI.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoID");

                    b.ToTable("alunos");
                });

            modelBuilder.Entity("PROVAAPI.Models.Imc", b =>
                {
                    b.Property<int>("ImcID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Altura")
                        .HasColumnType("REAL");

                    b.Property<int>("AlunoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Obesidade")
                        .HasColumnType("TEXT");

                    b.Property<float>("Peso")
                        .HasColumnType("REAL");

                    b.Property<float>("ResultadoConta")
                        .HasColumnType("REAL");

                    b.Property<string>("ResultadoFinalImc")
                        .HasColumnType("TEXT");

                    b.HasKey("ImcID");

                    b.HasIndex("AlunoID");

                    b.ToTable("imcs");
                });

            modelBuilder.Entity("PROVAAPI.Models.Imc", b =>
                {
                    b.HasOne("PROVAAPI.Models.Aluno", "aluno")
                        .WithMany()
                        .HasForeignKey("AlunoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aluno");
                });
#pragma warning restore 612, 618
        }
    }
}