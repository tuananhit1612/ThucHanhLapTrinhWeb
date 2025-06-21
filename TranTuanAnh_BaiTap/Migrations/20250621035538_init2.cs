using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranTuanAnh_BaiTap.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_DonHang_DonHangID",
                table: "TuanAnh_ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_Xe_XeID",
                table: "TuanAnh_ChiTietDonHang");

            migrationBuilder.RenameColumn(
                name: "NgayDat",
                table: "TuanAnh_DonHang",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "KhachHang",
                table: "TuanAnh_DonHang",
                newName: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "DonHangID",
                table: "TuanAnh_DonHang",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "XeID",
                table: "TuanAnh_ChiTietDonHang",
                newName: "XeId");

            migrationBuilder.RenameColumn(
                name: "SoLuong",
                table: "TuanAnh_ChiTietDonHang",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "DonHangID",
                table: "TuanAnh_ChiTietDonHang",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "ChiTietDonHangID",
                table: "TuanAnh_ChiTietDonHang",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TuanAnh_ChiTietDonHang_XeID",
                table: "TuanAnh_ChiTietDonHang",
                newName: "IX_TuanAnh_ChiTietDonHang_XeId");

            migrationBuilder.RenameIndex(
                name: "IX_TuanAnh_ChiTietDonHang_DonHangID",
                table: "TuanAnh_ChiTietDonHang",
                newName: "IX_TuanAnh_ChiTietDonHang_OrderId");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TuanAnh_DonHang",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "TuanAnh_DonHang",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TuanAnh_DonHang",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "TuanAnh_ChiTietDonHang",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_TuanAnh_DonHang_UserId",
                table: "TuanAnh_DonHang",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_DonHang_OrderId",
                table: "TuanAnh_ChiTietDonHang",
                column: "OrderId",
                principalTable: "TuanAnh_DonHang",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_Xe_XeId",
                table: "TuanAnh_ChiTietDonHang",
                column: "XeId",
                principalTable: "TuanAnh_Xe",
                principalColumn: "XeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TuanAnh_DonHang_AspNetUsers_UserId",
                table: "TuanAnh_DonHang",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_DonHang_OrderId",
                table: "TuanAnh_ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_Xe_XeId",
                table: "TuanAnh_ChiTietDonHang");

            migrationBuilder.DropForeignKey(
                name: "FK_TuanAnh_DonHang_AspNetUsers_UserId",
                table: "TuanAnh_DonHang");

            migrationBuilder.DropIndex(
                name: "IX_TuanAnh_DonHang_UserId",
                table: "TuanAnh_DonHang");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TuanAnh_DonHang");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "TuanAnh_DonHang");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TuanAnh_DonHang");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "TuanAnh_ChiTietDonHang");

            migrationBuilder.RenameColumn(
                name: "ShippingAddress",
                table: "TuanAnh_DonHang",
                newName: "KhachHang");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "TuanAnh_DonHang",
                newName: "NgayDat");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TuanAnh_DonHang",
                newName: "DonHangID");

            migrationBuilder.RenameColumn(
                name: "XeId",
                table: "TuanAnh_ChiTietDonHang",
                newName: "XeID");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "TuanAnh_ChiTietDonHang",
                newName: "SoLuong");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "TuanAnh_ChiTietDonHang",
                newName: "DonHangID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TuanAnh_ChiTietDonHang",
                newName: "ChiTietDonHangID");

            migrationBuilder.RenameIndex(
                name: "IX_TuanAnh_ChiTietDonHang_XeId",
                table: "TuanAnh_ChiTietDonHang",
                newName: "IX_TuanAnh_ChiTietDonHang_XeID");

            migrationBuilder.RenameIndex(
                name: "IX_TuanAnh_ChiTietDonHang_OrderId",
                table: "TuanAnh_ChiTietDonHang",
                newName: "IX_TuanAnh_ChiTietDonHang_DonHangID");

            migrationBuilder.AddForeignKey(
                name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_DonHang_DonHangID",
                table: "TuanAnh_ChiTietDonHang",
                column: "DonHangID",
                principalTable: "TuanAnh_DonHang",
                principalColumn: "DonHangID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TuanAnh_ChiTietDonHang_TuanAnh_Xe_XeID",
                table: "TuanAnh_ChiTietDonHang",
                column: "XeID",
                principalTable: "TuanAnh_Xe",
                principalColumn: "XeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
