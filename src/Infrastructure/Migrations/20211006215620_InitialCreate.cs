using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinAge = table.Column<int>(type: "int", nullable: false),
                    MaxAge = table.Column<int>(type: "int", nullable: false),
                    MinWeight = table.Column<int>(type: "int", nullable: false),
                    MaxWeight = table.Column<int>(type: "int", nullable: false),
                    MinHeight = table.Column<int>(type: "int", nullable: false),
                    MaxHeight = table.Column<int>(type: "int", nullable: false),
                    GpsRadius = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    PreferencesId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Preferences_PreferencesId",
                        column: x => x.PreferencesId,
                        principalTable: "Preferences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FriendUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FriendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendUsers", x => new { x.UserId, x.FriendId });
                    table.ForeignKey(
                        name: "FK_FriendUsers_Users_FriendId",
                        column: x => x.FriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    UserOneId = table.Column<int>(type: "int", nullable: false),
                    UserTwoId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => new { x.UserOneId, x.UserTwoId });
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserOneId",
                        column: x => x.UserOneId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_Users_UserTwoId",
                        column: x => x.UserTwoId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhotos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatUserOneId = table.Column<int>(type: "int", nullable: true),
                    ChatUserTwoId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SendTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatUserOneId_ChatUserTwoId",
                        columns: x => new { x.ChatUserOneId, x.ChatUserTwoId },
                        principalTable: "Chats",
                        principalColumns: new[] { "UserOneId", "UserTwoId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "ChatUserOneId", "ChatUserTwoId", "SendTime", "Text" },
                values: new object[] { 1, null, null, new DateTime(2021, 10, 6, 23, 51, 19, 857, DateTimeKind.Local).AddTicks(9565), "Hello there" });

            migrationBuilder.InsertData(
                table: "Preferences",
                columns: new[] { "Id", "GpsRadius", "MaxAge", "MaxHeight", "MaxWeight", "MinAge", "MinHeight", "MinWeight" },
                values: new object[] { 1, 5, 25, 175, 90, 19, 150, 50 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Birthdate", "Gender", "Height", "Latitude", "Longitude", "Name", "PreferencesId", "Surname", "UserId", "Weight" },
                values: new object[] { 1, "I am Franta.", new DateTime(2003, 10, 6, 21, 56, 19, 857, DateTimeKind.Utc).AddTicks(5248), 0, 200, 2.0, 1.0, "Franta", 1, "Jahoda", null, 100 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Birthdate", "Gender", "Height", "Latitude", "Longitude", "Name", "PreferencesId", "Surname", "UserId", "Weight" },
                values: new object[] { 2, "I am Frantiska.", new DateTime(2001, 10, 6, 21, 56, 19, 857, DateTimeKind.Utc).AddTicks(7318), 1, 150, 2.0, 1.0, "Frantiska", 1, "Jahodova", null, 50 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Birthdate", "Gender", "Height", "Latitude", "Longitude", "Name", "PreferencesId", "Surname", "UserId", "Weight" },
                values: new object[] { 3, "", new DateTime(1981, 10, 6, 21, 56, 19, 857, DateTimeKind.Utc).AddTicks(7332), 2, 185, 3.0, 2.0, "Petr", 1, "Smutný", null, 94 });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "UserOneId", "UserTwoId", "Name" },
                values: new object[] { 1, 2, "Our chat" });

            migrationBuilder.InsertData(
                table: "FriendUsers",
                columns: new[] { "FriendId", "UserId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "UserPhotos",
                columns: new[] { "Id", "Image", "UserId" },
                values: new object[] { 1, null, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FriendUsers_FriendId",
                table: "FriendUsers",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserTwoId",
                table: "Chats",
                column: "UserTwoId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatUserOneId_ChatUserTwoId",
                table: "Messages",
                columns: new[] { "ChatUserOneId", "ChatUserTwoId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserPhotos_UserId",
                table: "UserPhotos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PreferencesId",
                table: "Users",
                column: "PreferencesId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendUsers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "UserPhotos");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Preferences");
        }
    }
}
