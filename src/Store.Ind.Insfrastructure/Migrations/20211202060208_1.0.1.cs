using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Ind.Insfrastructure.Migrations
{
    public partial class _101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Variants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Variants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Variants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TypeColor",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeColor", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "TypeSize",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeSize", x => x.Code);
                });

            migrationBuilder.InsertData(
                table: "TypeColor",
                columns: new[] { "Code", "Description" },
                values: new object[,]
                {
                    { 1, "Black" },
                    { 7, "Blue" },
                    { 0, "White" },
                    { 5, "Brown" },
                    { 3, "Green" },
                    { 6, "Grey" },
                    { 2, "Red" },
                    { 4, "Yellow" }
                });

            migrationBuilder.InsertData(
                table: "TypeSize",
                columns: new[] { "Code", "Description" },
                values: new object[,]
                {
                    { 38, "XS" },
                    { 40, "S" },
                    { 42, "M" },
                    { 44, "L" },
                    { 46, "XL" },
                    { 48, "XXL" },
                    { 50, "XXXL" },
                    { 52, "XXXXL" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TypeColor");

            migrationBuilder.DropTable(
                name: "TypeSize");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Variants");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Variants");
        }
    }
}
