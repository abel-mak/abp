using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookstore.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppOrders_BookId",
                table: "AppOrders");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_BookId",
                table: "AppOrders",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AppOrders_BookId",
                table: "AppOrders");

            migrationBuilder.CreateIndex(
                name: "IX_AppOrders_BookId",
                table: "AppOrders",
                column: "BookId",
                unique: true);
        }
    }
}
