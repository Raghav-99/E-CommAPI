using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class fk_testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblProducts_ProductPId",
                table: "tblCommodities");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblSeller_SellerUsername",
                table: "tblCommodities");

            migrationBuilder.DropIndex(
                name: "IX_tblCommodities_ProductPId",
                table: "tblCommodities");

            migrationBuilder.DropIndex(
                name: "IX_tblCommodities_SellerUsername",
                table: "tblCommodities");

            migrationBuilder.DropColumn(
                name: "ProductPId",
                table: "tblCommodities");

            migrationBuilder.DropColumn(
                name: "SellerUsername",
                table: "tblCommodities");

            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "tblCommodities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "tblCommodities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PId",
                table: "tblCommodities");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "tblCommodities");

            migrationBuilder.AddColumn<int>(
                name: "ProductPId",
                table: "tblCommodities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerUsername",
                table: "tblCommodities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblCommodities_ProductPId",
                table: "tblCommodities",
                column: "ProductPId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCommodities_SellerUsername",
                table: "tblCommodities",
                column: "SellerUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCommodities_tblProducts_ProductPId",
                table: "tblCommodities",
                column: "ProductPId",
                principalTable: "tblProducts",
                principalColumn: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCommodities_tblSeller_SellerUsername",
                table: "tblCommodities",
                column: "SellerUsername",
                principalTable: "tblSeller",
                principalColumn: "Username");
        }
    }
}
