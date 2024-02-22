using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServisTakipWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class migg_add_customer_faulttrack_relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerID",
                table: "FaultTracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FaultTracks_CustomerID",
                table: "FaultTracks",
                column: "CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_FaultTracks_Customers_CustomerID",
                table: "FaultTracks",
                column: "CustomerID",
                principalTable: "Customers",
                principalColumn: "CustomerID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FaultTracks_Customers_CustomerID",
                table: "FaultTracks");

            migrationBuilder.DropIndex(
                name: "IX_FaultTracks_CustomerID",
                table: "FaultTracks");

            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "FaultTracks");
        }
    }
}
