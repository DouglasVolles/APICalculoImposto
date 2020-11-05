﻿// <auto-generated />
using APICalculoImposto.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APICalculoImposto.Migrations
{
    [DbContext(typeof(CalculoImpostoContext))]
    partial class CalculoImpostoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APICalculoImposto.Models.Contribuinte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantidadeDependente")
                        .HasColumnType("int");

                    b.Property<decimal>("QuantidadeSalarios")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RendaBruta")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("RendaLiquida")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorImpostoRenda")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorSalarioMinino")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Contribuintes");
                });
#pragma warning restore 612, 618
        }
    }
}
