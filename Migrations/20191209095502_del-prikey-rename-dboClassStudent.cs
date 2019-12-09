using Microsoft.EntityFrameworkCore.Migrations;

namespace firstApp.Migrations
{
    public partial class delprikeyrenamedboClassStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent");

            migrationBuilder.DropIndex(
                name: "IX_ClassStudent_ClassId",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "ClassStudentId",
                table: "ClassStudent");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "Classes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent",
                columns: new[] { "ClassId", "StudentId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "ClassStudentId",
                table: "ClassStudent",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "Classes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent",
                column: "ClassStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_ClassId",
                table: "ClassStudent",
                column: "ClassId");
        }
    }
}
