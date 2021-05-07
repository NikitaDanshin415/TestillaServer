using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class TestCases3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TestCaseId",
                table: "TestSteps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestSteps_TestCaseId",
                table: "TestSteps",
                column: "TestCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_TestSteps_TestCases_TestCaseId",
                table: "TestSteps",
                column: "TestCaseId",
                principalTable: "TestCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestSteps_TestCases_TestCaseId",
                table: "TestSteps");

            migrationBuilder.DropIndex(
                name: "IX_TestSteps_TestCaseId",
                table: "TestSteps");

            migrationBuilder.DropColumn(
                name: "TestCaseId",
                table: "TestSteps");
        }
    }
}
