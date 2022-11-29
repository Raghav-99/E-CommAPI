using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class fk_relation_iteration2_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "tblCommodities",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblCommodities_PId",
                table: "tblCommodities",
                column: "PId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCommodities_Username",
                table: "tblCommodities",
                column: "Username");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCommodities_tblProducts_PId",
                table: "tblCommodities",
                column: "PId",
                principalTable: "tblProducts",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblCommodities_tblSeller_Username",
                table: "tblCommodities",
                column: "Username",
                principalTable: "tblSeller",
                principalColumn: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblProducts_PId",
                table: "tblCommodities");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblSeller_Username",
                table: "tblCommodities");

            migrationBuilder.DropIndex(
                name: "IX_tblCommodities_PId",
                table: "tblCommodities");

            migrationBuilder.DropIndex(
                name: "IX_tblCommodities_Username",
                table: "tblCommodities");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "tblCommodities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
