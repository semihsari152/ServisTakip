using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServisTakipWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class migg_add_productmovements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductMovements",
                columns: table => new
                {
                    MovementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovementDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaultTrackingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMovements", x => x.MovementID);
                    table.ForeignKey(
                        name: "FK_ProductMovements_FaultTracks_FaultTrackingID",
                        column: x => x.FaultTrackingID,
                        principalTable: "FaultTracks",
                        principalColumn: "FaultTrackingID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductMovements_FaultTrackingID",
                table: "ProductMovements",
                column: "FaultTrackingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductMovements");
        }
    }
}
