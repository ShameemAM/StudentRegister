using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegister.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changesMAdeToTheSchemaStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ClassXIIPercentage",
                table: "Qualifications",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentHobbies_StudentId",
                table: "StudentHobbies",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDetails_CourseId",
                table: "StudentDetails",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualifications_StudentId",
                table: "Qualifications",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Qualifications_StudentDetails_StudentId",
                table: "Qualifications",
                column: "StudentId",
                principalTable: "StudentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentDetails_Courses_CourseId",
                table: "StudentDetails",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentHobbies_StudentDetails_StudentId",
                table: "StudentHobbies",
                column: "StudentId",
                principalTable: "StudentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Qualifications_StudentDetails_StudentId",
                table: "Qualifications");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentDetails_Courses_CourseId",
                table: "StudentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentHobbies_StudentDetails_StudentId",
                table: "StudentHobbies");

            migrationBuilder.DropIndex(
                name: "IX_StudentHobbies_StudentId",
                table: "StudentHobbies");

            migrationBuilder.DropIndex(
                name: "IX_StudentDetails_CourseId",
                table: "StudentDetails");

            migrationBuilder.DropIndex(
                name: "IX_Qualifications_StudentId",
                table: "Qualifications");

            migrationBuilder.AlterColumn<float>(
                name: "ClassXIIPercentage",
                table: "Qualifications",
                type: "real",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }
    }
}
