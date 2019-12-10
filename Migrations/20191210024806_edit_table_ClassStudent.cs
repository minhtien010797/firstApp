using Microsoft.EntityFrameworkCore.Migrations;

namespace firstApp.Migrations
{
    public partial class edit_table_ClassStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudent_Classes_ClassId",
                table: "ClassStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudent_Students_StudentId",
                table: "ClassStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent");

            migrationBuilder.DropIndex(
                name: "IX_ClassStudent_ClassId",
                table: "ClassStudent");

            migrationBuilder.DropColumn(
                name: "ClassStudentId",
                table: "ClassStudent");

            migrationBuilder.RenameTable(
                name: "ClassStudent",
                newName: "ClassStudents");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudent_StudentId",
                table: "ClassStudents",
                newName: "IX_ClassStudents_StudentId");

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
                name: "PK_ClassStudents",
                table: "ClassStudents",
                columns: new[] { "ClassId", "StudentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_Classes_ClassId",
                table: "ClassStudents",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudents_Students_StudentId",
                table: "ClassStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_Classes_ClassId",
                table: "ClassStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ClassStudents_Students_StudentId",
                table: "ClassStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassStudents",
                table: "ClassStudents");

            migrationBuilder.RenameTable(
                name: "ClassStudents",
                newName: "ClassStudent");

            migrationBuilder.RenameIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudent",
                newName: "IX_ClassStudent_StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "StudentName",
                table: "Students",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ClassName",
                table: "Classes",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassStudent",
                table: "ClassStudent",
                column: "ClassStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudent_ClassId",
                table: "ClassStudent",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudent_Classes_ClassId",
                table: "ClassStudent",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "ClassId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClassStudent_Students_StudentId",
                table: "ClassStudent",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
