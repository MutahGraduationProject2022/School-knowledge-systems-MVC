using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SKC_MVC.Migrations
{
    /// <inheritdoc />
    public partial class dataSeeding1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "NumberOfClassesPerWeek", "NumberOfStudents" },
                values: new object[] { 1, 5, 30 });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Class", "Name", "Section", "SectionId" },
                values: new object[] { 1, "Some Class", "John Doe", "A", null });

            migrationBuilder.InsertData(
                table: "ClSeSus",
                columns: new[] { "Id", "ClassId", "Flag", "NumOfClassPerWeek" },
                values: new object[] { 1, 1, true, 4 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Exam1", "Exam2", "FinalExam", "Homeworks", "StudentId", "TotalGrades" },
                values: new object[] { 1, 88, 92, 85, 95, 1, 90 });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "ClassId", "Count" },
                values: new object[] { 1, 1, 25 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClSeSus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
