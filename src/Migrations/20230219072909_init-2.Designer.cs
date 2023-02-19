﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using BET.Infrastructure;

#nullable disable

namespace BET.Migrations
{
    [DbContext(typeof(BEDbContext))]
    [Migration("20230219072909_init-2")]
    partial class init2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Deparment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(192)
                        .HasColumnType("nvarchar(192)");

                    b.HasKey("Id");

                    b.ToTable("Deparments", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.DeparmentEmployee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("DeparmentId")
                        .HasColumnType("bigint");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DeparmentId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("DeparmentEmployees", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("Avatar")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(192)
                        .HasColumnType("nvarchar(192)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("WebApplication1.Models.DeparmentEmployee", b =>
                {
                    b.HasOne("WebApplication1.Models.Deparment", "Deparment")
                        .WithMany("DeparmentEmployee")
                        .HasForeignKey("DeparmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Employee", "Employee")
                        .WithMany("DeparmentEmployee")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deparment");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("WebApplication1.Models.Deparment", b =>
                {
                    b.Navigation("DeparmentEmployee");
                });

            modelBuilder.Entity("WebApplication1.Models.Employee", b =>
                {
                    b.Navigation("DeparmentEmployee");
                });
#pragma warning restore 612, 618
        }
    }
}
