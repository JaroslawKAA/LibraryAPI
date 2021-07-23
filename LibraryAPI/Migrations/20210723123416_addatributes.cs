using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryAPI.Migrations
{
    public partial class addatributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Bookcase_BookcaseId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_User_OwnerId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowing_User_BorrowerId",
                table: "Borrowing");

            migrationBuilder.DropForeignKey(
                name: "FK_Borrowing_User_ClientId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Borrowing_BorrowerId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Borrowing_ClientId",
                table: "Borrowing");

            migrationBuilder.DropIndex(
                name: "IX_Book_BookcaseId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_OwnerId",
                table: "Book");

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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookcaseId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BarcodeNumber",
                table: "Book",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Authors",
                table: "Book",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "OwnerId",
                table: "Book",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "BookcaseId",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BarcodeNumber",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Authors",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_BorrowerId",
                table: "Borrowing",
                column: "BorrowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Borrowing_ClientId",
                table: "Borrowing",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_BookcaseId",
                table: "Book",
                column: "BookcaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_OwnerId",
                table: "Book",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Bookcase_BookcaseId",
                table: "Book",
                column: "BookcaseId",
                principalTable: "Bookcase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Book_User_OwnerId",
                table: "Book",
                column: "OwnerId",
                principalTable: "User",
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
    }
}
