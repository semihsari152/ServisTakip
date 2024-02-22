using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServisTakipWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_change_collection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaultTracks_Customers_CustomerID",
                table: "FaultTracks");

            migrationBuilder.DropForeignKey(
                name: "FK_FaultTracks_Products_ProductID",
                table: "FaultTracks");

            migrationBuilder.DropIndex(
                name: "IX_FaultTracks_CustomerID",
                table: "FaultTracks");

            migrationBuilder.DropIndex(
                name: "IX_FaultTracks_ProductID",
                table: "FaultTracks");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "FaultTracks");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "FaultTracks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "FaultTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "FaultTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FaultTracks_CustomerID",
                table: "FaultTracks",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_FaultTracks_ProductID",
                table: "FaultTracks",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultTracks_Customers_CustomerID",
                table: "FaultTracks",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaultTracks_Products_ProductID",
                table: "FaultTracks",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
