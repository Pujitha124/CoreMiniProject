using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMiniProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) // migration to add nything 
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Custid = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    Balance = table.Column<decimal>(type: "Money", nullable: true),
                    City = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Custid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) // using to delete or revert 
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
