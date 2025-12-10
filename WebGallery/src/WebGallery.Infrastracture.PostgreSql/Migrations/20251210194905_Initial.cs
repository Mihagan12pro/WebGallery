using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGallery.Infrastracture.PostgreSql.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Comments",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        UserId = table.Column<Guid>(type: "uuid", nullable: false),
            //        EntityId = table.Column<Guid>(type: "uuid", nullable: false),
            //        DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        Body = table.Column<string>(type: "text", nullable: false),
            //        Likes = table.Column<int>(type: "integer", nullable: false),
            //        DisLikes = table.Column<int>(type: "integer", nullable: false),
            //        CommentId = table.Column<Guid>(type: "uuid", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Comments", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Comments_Comments_CommentId",
            //            column: x => x.CommentId,
            //            principalTable: "Comments",
            //            principalColumn: "Id");
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        UserName = table.Column<string>(type: "text", nullable: false),
            //        Email = table.Column<string>(type: "text", nullable: false),
            //        PasswordHash = table.Column<string>(type: "text", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Comments_CommentId",
            //    table: "Comments",
            //    column: "CommentId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_Email",
            //    table: "Users",
            //    column: "Email",
            //    unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Comments");

            //migrationBuilder.DropTable(
            //    name: "Users");
        }
    }
}
