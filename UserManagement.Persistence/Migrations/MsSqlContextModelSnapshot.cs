﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace UserManagement.Persistence.Migrations
{
    [DbContext(typeof(MsSqlContext))]
    partial class MsSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserManagement.Domain.Model.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)")
                        .HasColumnName("Uf");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("UserManagement.Domain.Model.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("Age");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)")
                        .HasColumnName("Cpf");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Person", "dbo");
                });

            modelBuilder.Entity("UserManagement.Domain.Model.Person", b =>
                {
                    b.HasOne("UserManagement.Domain.Model.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });
#pragma warning restore 612, 618
        }
    }
}