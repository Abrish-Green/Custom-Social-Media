using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSocialMedia.Migrations
{
    public partial class AddedNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentContent = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Informations",
                columns: table => new
                {
                    Phone = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Job = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    ProfilePictureUrl = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    FromUserId = table.Column<string>(type: "text", nullable: false),
                    ToUserId = table.Column<string>(type: "text", nullable: false),
                    TextMessage = table.Column<string>(type: "text", nullable: true),
                    MessageDateInformation = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MyFollowers",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsFollowedBack = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MyFollowings",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    isFollower = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "MyFriends",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsFriend = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Notificaitons",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FollowerNotification = table.Column<int>(type: "integer", nullable: false),
                    MessageNotification = table.Column<int>(type: "integer", nullable: false),
                    NewsFeedNotification = table.Column<int>(type: "integer", nullable: false),
                    FriendRequestNotification = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PostTitle = table.Column<string>(type: "text", nullable: false),
                    PostContent = table.Column<string>(type: "text", nullable: false),
                    PostDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PostsId = table.Column<string>(type: "text", nullable: false),
                    Hide = table.Column<bool>(type: "boolean", nullable: false),
                    Catagory = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Posts_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storys",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PostTitle = table.Column<string>(type: "text", nullable: false),
                    PostContent = table.Column<string>(type: "text", nullable: false),
                    PostedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PostExpiredDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storys", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostsId",
                table: "Posts",
                column: "PostsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Informations");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "MyFollowers");

            migrationBuilder.DropTable(
                name: "MyFollowings");

            migrationBuilder.DropTable(
                name: "MyFriends");

            migrationBuilder.DropTable(
                name: "Notificaitons");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Storys");
        }
    }
}
