﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Search.DatabaseAndStoring;

namespace Search.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210808134925_File and DataAndFile tables added")]
    partial class FileandDataAndFiletablesadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Search.Models.Data", b =>
                {
                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Word");

                    b.ToTable("Data");
                });

            modelBuilder.Entity("Search.Models.DataAndFile", b =>
                {
                    b.Property<string>("DataKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("FileKey")
                        .HasColumnType("int");

                    b.HasKey("DataKey", "FileKey");

                    b.ToTable("DataAndFiles");
                });

            modelBuilder.Entity("Search.Models.File", b =>
                {
                    b.Property<int>("HashCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HashCode");

                    b.ToTable("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
