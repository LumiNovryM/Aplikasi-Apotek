﻿// <auto-generated />
using System;
using Aplikasi_Apotek.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aplikasi_Apotek.Migrations
{
    [DbContext(typeof(ApotekContext))]
    [Migration("20240104143304_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aplikasi_Apotek.Models.Barang", b =>
                {
                    b.Property<int>("Id_barang")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_barang"));

                    b.Property<DateTime>("Expired_date")
                        .HasColumnType("datetime2");

                    b.Property<long>("Harga_Satuan")
                        .HasColumnType("bigint");

                    b.Property<long>("Jumlah_barang")
                        .HasColumnType("bigint");

                    b.Property<string>("Kode_barang")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nama_barang")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Satuan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_barang");

                    b.ToTable("Barang");
                });

            modelBuilder.Entity("Aplikasi_Apotek.Models.Log", b =>
                {
                    b.Property<int>("Id_log")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_log"));

                    b.Property<string>("Aktivitas")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Id_user")
                        .HasColumnType("int");

                    b.Property<DateTime>("Waktu")
                        .HasColumnType("datetime2");

                    b.HasKey("Id_log");

                    b.HasIndex("Id_user");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("Aplikasi_Apotek.Models.Transaksi", b =>
                {
                    b.Property<int>("Id_transaksi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_transaksi"));

                    b.Property<int>("Id_barang")
                        .HasColumnType("int");

                    b.Property<int>("Id_user")
                        .HasColumnType("int");

                    b.Property<string>("No_transaksi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Tgl_transaksi")
                        .HasColumnType("datetime2");

                    b.Property<long>("Total_bayar")
                        .HasColumnType("bigint");

                    b.HasKey("Id_transaksi");

                    b.HasIndex("Id_barang");

                    b.HasIndex("Id_user");

                    b.ToTable("Transaksi");
                });

            modelBuilder.Entity("Aplikasi_Apotek.Models.User", b =>
                {
                    b.Property<int>("Id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_user"));

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nama")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telpon")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tipe_user")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_user");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Aplikasi_Apotek.Models.Log", b =>
                {
                    b.HasOne("Aplikasi_Apotek.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("Id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Aplikasi_Apotek.Models.Transaksi", b =>
                {
                    b.HasOne("Aplikasi_Apotek.Models.Barang", "Barang")
                        .WithMany()
                        .HasForeignKey("Id_barang")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aplikasi_Apotek.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("Id_user")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Barang");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}