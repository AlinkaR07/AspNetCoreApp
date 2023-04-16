﻿// <auto-generated />
using System;
using AspNetCoreApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspNetCoreApp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230313075654_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspNetCoreApp.Models.LineOrder", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CodTovara_FK_")
                        .HasColumnType("int");

                    b.Property<int>("CountOrder")
                        .HasColumnType("int");

                    b.Property<int?>("CountShipment")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataManuf")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOrder_FK_")
                        .HasColumnType("int");

                    b.Property<string>("PurchasePrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TovarCodTovara")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NumberOrder_FK_");

                    b.HasIndex("TovarCodTovara");

                    b.ToTable("LineOrder");
                });

            modelBuilder.Entity("AspNetCoreApp.Models.LineWrite", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CodTovara_FK_")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberActWrite_FK_")
                        .HasColumnType("int");

                    b.Property<double>("Summa")
                        .HasColumnType("float");

                    b.Property<int>("TovarCodTovara")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NumberActWrite_FK_");

                    b.HasIndex("TovarCodTovara");

                    b.ToTable("LineWrite");
                });

            modelBuilder.Entity("AspNetCoreApp.Models.Order", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Number"));

                    b.Property<DateTime?>("DataOrder")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataShipment")
                        .HasColumnType("datetime2");

                    b.Property<string>("FIOworker_FK_")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOrganizationPostavshik_FK_")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusOrder")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("AspNetCoreApp.Models.Tovar", b =>
                {
                    b.Property<int>("CodTovara")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodTovara"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateExpiration")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("CodTovara");

                    b.ToTable("Tovar");
                });

            modelBuilder.Entity("AspNetCoreApp.Models.Write", b =>
                {
                    b.Property<int>("NumberAct")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumberAct"));

                    b.Property<DateTime>("DataWrite")
                        .HasColumnType("datetime2");

                    b.Property<string>("FIOworker_FK_")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NumberAct");

                    b.ToTable("Write");
                });

            modelBuilder.Entity("AspNetCoreApp.Models.LineOrder", b =>
                {
                    b.HasOne("AspNetCoreApp.Models.Order", "Order")
                        .WithMany("LineOrders")
                        .HasForeignKey("NumberOrder_FK_")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreApp.Models.Tovar", "Tovar")
                        .WithMany()
                        .HasForeignKey("TovarCodTovara")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Tovar");
                });

            modelBuilder.Entity("AspNetCoreApp.Models.LineWrite", b =>
                {
                    b.HasOne("AspNetCoreApp.Models.Write", "Write")
                        .WithMany("LineWrites")
                        .HasForeignKey("NumberActWrite_FK_")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AspNetCoreApp.Models.Tovar", "Tovar")
                        .WithMany()
                        .HasForeignKey("TovarCodTovara")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tovar");

                    b.Navigation("Write");
                });

            modelBuilder.Entity("AspNetCoreApp.Models.Order", b =>
                {
                    b.Navigation("LineOrders");
                });

            modelBuilder.Entity("AspNetCoreApp.Models.Write", b =>
                {
                    b.Navigation("LineWrites");
                });
#pragma warning restore 612, 618
        }
    }
}
