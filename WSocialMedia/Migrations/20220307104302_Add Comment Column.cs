using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSocialMedia.Migrations
{
    public partial class AddCommentColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentUserName",
                table: "Comments",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentUserName",
                table: "Comments");
        }
    }
}
