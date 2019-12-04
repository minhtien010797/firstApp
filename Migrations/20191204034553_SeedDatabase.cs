using Microsoft.EntityFrameworkCore.Migrations;

namespace firstApp.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Classes(ClassName) VALUES ('1A')");
            migrationBuilder.Sql("INSERT INTO Classes(ClassName) VALUES ('2A')");
            migrationBuilder.Sql("INSERT INTO Classes(ClassName) VALUES ('3A')");
            migrationBuilder.Sql("INSERT INTO Classes(ClassName) VALUES ('4A')");

            migrationBuilder.Sql("INSERT INTO Students(StudentName) VALUES ('Nguyen Van 1')");
            migrationBuilder.Sql("INSERT INTO Students(StudentName) VALUES ('Nguyen Van 3')");
            migrationBuilder.Sql("INSERT INTO Students(StudentName) VALUES ('Nguyen Van 5')");
            migrationBuilder.Sql("INSERT INTO Students(StudentName) VALUES ('Nguyen Van 7')");

            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='1A'),(Select StudentId From Students where StudentName='Nguyen Van 1'))");
            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='1A'),(Select StudentId From Students where StudentName='Nguyen Van 5'))");
            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='1A'),(Select StudentId From Students where StudentName='Nguyen Van 7'))");
            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='2A'),(Select StudentId From Students where StudentName='Nguyen Van 3'))");
            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='2A'),(Select StudentId From Students where StudentName='Nguyen Van 7'))");
            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='3A'),(Select StudentId From Students where StudentName='Nguyen Van 3'))");
            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='3A'),(Select StudentId From Students where StudentName='Nguyen Van 1'))");
            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='4A'),(Select StudentId From Students where StudentName='Nguyen Van 5'))");
            migrationBuilder.Sql("INSERT INTO ClassStudent(ClassId,StudentId) VALUES ((Select ClassId From Classes where ClassName='4A'),(Select StudentId From Students where StudentName='Nguyen Van 1'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From ClassStudent");
        }
    }
}
