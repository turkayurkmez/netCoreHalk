using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eshop.DataAccess.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Features",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bilgisayar" },
                    { 2, "Ses Sistemleri" },
                    { 3, "Televizyon" },
                    { 4, "Ev Elektroniği" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Features", "ImageUrl", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Dell XPS Açıklama", null, "https://cdn03.ciceksepeti.com/cicek/kcm61759377-1/XL/dell-xps-13-9310-i7-1185g7-vpro-16gb-1tb-ssd-13.4-fhd-windows-10-pro-kcm61759377-1-54e81e24abbf459daed90890fb52d84e.jpg", "Dell XPS 13", 35000m, 10 },
                    { 2, 1, "Macbook", null, "https://cdn03.ciceksepeti.com/cicek/kcm61759377-1/XL/dell-xps-13-9310-i7-1185g7-vpro-16gb-1tb-ssd-13.4-fhd-windows-10-pro-kcm61759377-1-54e81e24abbf459daed90890fb52d84e.jpg", "Macbook M2", 75000m, 10 },
                    { 3, 2, "Sony 5+1", null, "https://cdn03.ciceksepeti.com/cicek/kcm61759377-1/XL/dell-xps-13-9310-i7-1185g7-vpro-16gb-1tb-ssd-13.4-fhd-windows-10-pro-kcm61759377-1-54e81e24abbf459daed90890fb52d84e.jpg", "Sony", 3500m, 10 },
                    { 4, 2, "Samsung Bar", null, "https://cdn03.ciceksepeti.com/cicek/kcm61759377-1/XL/dell-xps-13-9310-i7-1185g7-vpro-16gb-1tb-ssd-13.4-fhd-windows-10-pro-kcm61759377-1-54e81e24abbf459daed90890fb52d84e.jpg", "BT Bar", 10000m, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Features",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
