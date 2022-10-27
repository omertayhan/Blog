using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.Migrations
{
    public partial class MySixthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UsersId",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Blogs",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_UsersId",
                table: "Blogs",
                newName: "IX_Blogs_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_UserId",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Blogs",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                newName: "IX_Blogs_UsersId");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_UsersId",
                table: "Blogs",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
