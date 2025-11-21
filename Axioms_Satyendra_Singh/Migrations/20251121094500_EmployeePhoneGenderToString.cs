using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Axioms_Satyendra_Singh.Migrations
{
    public partial class EmployeePhoneGenderToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Alter Employee.Gender and Employee.Phone_No from int to string (nvarchar(max))
            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Phone_No",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Phone_No",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
