using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranTuanAnh_BaiTap.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TuanAnh_DonHang",
                columns: table => new
                {
                    DonHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NgayDat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KhachHang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuanAnh_DonHang", x => x.DonHangID);
                });

            migrationBuilder.CreateTable(
                name: "TuanAnh_HangXe",
                columns: table => new
                {
                    HangXeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHang = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuanAnh_HangXe", x => x.HangXeID);
                });

            migrationBuilder.CreateTable(
                name: "TuanAnh_Xe",
                columns: table => new
                {
                    XeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HangXeID = table.Column<int>(type: "int", nullable: false),
                    TenXe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NgaySanXuat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuanAnh_Xe", x => x.XeID);
                    table.ForeignKey(
                        name: "FK_TuanAnh_Xe_TuanAnh_HangXe_HangXeID",
                        column: x => x.HangXeID,
                        principalTable: "TuanAnh_HangXe",
                        principalColumn: "HangXeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TuanAnh_ChiTietDonHang",
                columns: table => new
                {
                    ChiTietDonHangID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonHangID = table.Column<int>(type: "int", nullable: false),
                    XeID = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TuanAnh_ChiTietDonHang", x => x.ChiTietDonHangID);
                    table.ForeignKey(
                        name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_DonHang_DonHangID",
                        column: x => x.DonHangID,
                        principalTable: "TuanAnh_DonHang",
                        principalColumn: "DonHangID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_Xe_XeID",
                        column: x => x.XeID,
                        principalTable: "TuanAnh_Xe",
                        principalColumn: "XeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TuanAnh_ChiTietDonHang_DonHangID",
                table: "TuanAnh_ChiTietDonHang",
                column: "DonHangID");

            migrationBuilder.CreateIndex(
                name: "IX_TuanAnh_ChiTietDonHang_XeID",
                table: "TuanAnh_ChiTietDonHang",
                column: "XeID");

            migrationBuilder.CreateIndex(
                name: "IX_TuanAnh_Xe_HangXeID",
                table: "TuanAnh_Xe",
                column: "HangXeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TuanAnh_ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "TuanAnh_DonHang");

            migrationBuilder.DropTable(
                name: "TuanAnh_Xe");

            migrationBuilder.DropTable(
                name: "TuanAnh_HangXe");
        }
    }
}
