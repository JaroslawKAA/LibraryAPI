using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class objectsInsteadIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Borrowing",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BorrowerId",
                table: "Borrowing",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrowing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Book",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_BookId",
                table: "Borrowing",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_BorrowerId",
                table: "Borrowing",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_ClientId",
                table: "Borrowing",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_User",
                table: "Book",
                column: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_User_User",
                table: "Book",
                column: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowing_Book_BookId",
                table: "Borrowing",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowing_User_BorrowerId",
                table: "Borrowing",
                column: "BorrowerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowing_User_ClientId",
                table: "Borrowing",
                column: "ClientId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_User_User",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowing_Book_BookId",
                table: "Borrowing");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowing_User_BorrowerId",
                table: "Borrowing");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowing_User_ClientId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Borrowing_BookId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Borrowing_BorrowerId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Borrowing_ClientId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Book_User",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "User",
                table: "Book");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "User",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Borrowing",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BorrowerId",
                table: "Borrowing",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookId",
                table: "Borrowing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserId",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UserId",
                table: "User",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
