using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ValorantHubAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatedByField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Weapons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "createdBy",
                table: "Agents",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "createdBy",
                table: "Agents");
        }
    }
}
