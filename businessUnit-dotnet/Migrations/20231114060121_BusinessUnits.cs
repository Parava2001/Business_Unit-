using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace businessUnit.Migrations
{
    /// <inheritdoc />
    public partial class BusinessUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveDate",
                table: "businessUnits");

            migrationBuilder.RenameColumn(
                name: "LastUpdateUser",
                table: "businessUnits",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "LastUpdateDate",
                table: "businessUnits",
                newName: "BusinessUnitName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "businessUnits",
                newName: "LastUpdateUser");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitName",
                table: "businessUnits",
                newName: "LastUpdateDate");

            migrationBuilder.AddColumn<string>(
                name: "ActiveDate",
                table: "businessUnits",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
