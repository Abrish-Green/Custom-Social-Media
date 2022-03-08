using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSocialMedia.Migrations
{
    public partial class Addedidtoinformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Informations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Informations",
                table: "Informations",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Informations",
                table: "Informations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Informations");
        }
    }
}
