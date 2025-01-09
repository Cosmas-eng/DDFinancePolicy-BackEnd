using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDFinancePolicy.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PolicyHolderId = table.Column<int>(type: "int", nullable: false),
                    PolicyHolderName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    PhoneNumber_CountryCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    PhoneNumber_Number = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    PhoneNumber_Extension = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Premuim = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolicyStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Policies");
        }
    }
}
