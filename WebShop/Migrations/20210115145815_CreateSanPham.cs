using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShop.Migrations
{
    public partial class CreateSanPham : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    IdSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiSP = table.Column<int>(type: "int", nullable: false),
                    DanhMuc = table.Column<int>(type: "int", nullable: false),
                    GiaNhap = table.Column<int>(type: "int", nullable: false),
                    GiaBan = table.Column<int>(type: "int", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThuongHieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    XuatXu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChatLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KhuyenMai = table.Column<int>(type: "int", nullable: false),
                    soluongDaBan = table.Column<int>(type: "int", nullable: false),
                    Ngaynhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.IdSanPham);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SanPham");
        }
    }
}
