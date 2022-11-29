using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class order_history_model_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "tblSeller",
                newName: "Sellername");

            migrationBuilder.CreateTable(
                name: "tblOrderHistory",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sellername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderHistory", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_tblOrderHistory_tblProducts_PId",
                        column: x => x.PId,
                        principalTable: "tblProducts",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOrderHistory_tblSeller_Sellername",
                        column: x => x.Sellername,
                        principalTable: "tblSeller",
                        principalColumn: "Sellername",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblOrderHistory_tblUser_Username",
                        column: x => x.Username,
                        principalTable: "tblUser",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderHistory_PId",
                table: "tblOrderHistory",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderHistory_Sellername",
                table: "tblOrderHistory",
                column: "Sellername");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderHistory_Username",
                table: "tblOrderHistory",
                column: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOrderHistory");

            migrationBuilder.RenameColumn(
                name: "Sellername",
                table: "tblSeller",
                newName: "Username");
        }
    }
}
