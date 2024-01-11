using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aplikasi_Apotek.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barang",
                columns: table => new
                {
                    Id_barang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kode_barang = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nama_barang = table.Column<string>(type: "varchar(50)", nullable: false),
                    Expired_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Jumlah_barang = table.Column<long>(type: "bigint", nullable: false),
                    Satuan = table.Column<string>(type: "varchar(50)", nullable: false),
                    Harga_Satuan = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barang", x => x.Id_barang);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipe_user = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nama = table.Column<string>(type: "varchar(50)", nullable: false),
                    Alamat = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telpon = table.Column<string>(type: "varchar(50)", nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_user);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    Id_log = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Waktu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Aktivitas = table.Column<string>(type: "varchar(50)", nullable: false),
                    Id_user = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.Id_log);
                    table.ForeignKey(
                        name: "FK_Log_User_Id_user",
                        column: x => x.Id_user,
                        principalTable: "User",
                        principalColumn: "Id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaksi",
                columns: table => new
                {
                    Id_transaksi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    No_transaksi = table.Column<string>(type: "varchar(50)", nullable: false),
                    Tgl_transaksi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_bayar = table.Column<long>(type: "bigint", nullable: false),
                    Id_user = table.Column<int>(type: "int", nullable: false),
                    Id_barang = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaksi", x => x.Id_transaksi);
                    table.ForeignKey(
                        name: "FK_Transaksi_Barang_Id_barang",
                        column: x => x.Id_barang,
                        principalTable: "Barang",
                        principalColumn: "Id_barang",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaksi_User_Id_user",
                        column: x => x.Id_user,
                        principalTable: "User",
                        principalColumn: "Id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Barang",
                columns: new[] { "Id_barang", "CreatedAt", "Expired_date", "Harga_Satuan", "Jumlah_barang", "Kode_barang", "Nama_barang", "Satuan", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(1862), 75000L, 100L, "OBT", "Obat Tidur", "Pcs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(1891), 5000L, 50L, "OBT", "Obat Maag", "Pcs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(1895), 25000L, 15L, "OBT", "Obat Pilek", "Pcs", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id_user", "Alamat", "CreatedAt", "Nama", "Password", "Telpon", "Tipe_user", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { 1, "JL Delima 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lumi", "Mysql@2023", "081288531636", "Admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lumi07" },
                    { 2, "JL Mangga 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Novry", null, "081244542479", "Kasir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "novry11" },
                    { 3, "JL Apel 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mekel", null, "089524790987", "Kasir", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "mekel2005" }
                });

            migrationBuilder.InsertData(
                table: "Log",
                columns: new[] { "Id_log", "Aktivitas", "CreatedAt", "Id_user", "UpdatedAt", "Waktu" },
                values: new object[,]
                {
                    { 1, "Login", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(4146) },
                    { 2, "Logout", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(4154) },
                    { 3, "Login", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(4156) }
                });

            migrationBuilder.InsertData(
                table: "Transaksi",
                columns: new[] { "Id_transaksi", "CreatedAt", "Id_barang", "Id_user", "No_transaksi", "Tgl_transaksi", "Total_bayar", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "001", new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(3549), 25000L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "002", new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(3561), 25000L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, "003", new DateTime(2024, 1, 11, 13, 57, 2, 808, DateTimeKind.Local).AddTicks(3564), 25000L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Log_Id_user",
                table: "Log",
                column: "Id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Transaksi_Id_barang",
                table: "Transaksi",
                column: "Id_barang");

            migrationBuilder.CreateIndex(
                name: "IX_Transaksi_Id_user",
                table: "Transaksi",
                column: "Id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Transaksi");

            migrationBuilder.DropTable(
                name: "Barang");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
