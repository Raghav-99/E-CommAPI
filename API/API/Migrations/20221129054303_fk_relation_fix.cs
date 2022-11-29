using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class fk_relation_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblProducts_ProductsModelPId",
                table: "tblCommodities");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblSeller_SellerModelUsername",
                table: "tblCommodities");

            migrationBuilder.DropIndex(
                name: "IX_tblCommodities_ProductsModelPId",
                table: "tblCommodities");

            migrationBuilder.DropIndex(
                name: "IX_tblCommodities_SellerModelUsername",
                table: "tblCommodities");

            migrationBuilder.DropColumn(
                name: "ProductsModelPId",
                table: "tblCommodities");

            migrationBuilder.DropColumn(
                name: "SellerModelUsername",
                table: "tblCommodities");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "tblCommodities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "tblCommodities");

            migrationBuilder.AddColumn<int>(
                name: "ProductsModelPId",
                table: "tblCommodities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerModelUsername",
                table: "tblCommodities",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblCommodities_ProductsModelPId",
                table: "tblCommodities",
                column: "ProductsModelPId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCommodities_SellerModelUsername",
                table: "tblCommodities",
                column: "SellerModelUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCommodities_tblProducts_ProductsModelPId",
                table: "tblCommodities",
                column: "ProductsModelPId",
                principalTable: "tblProducts",
                principalColumn: "PId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCommodities_tblSeller_SellerModelUsername",
                table: "tblCommodities",
                column: "SellerModelUsername",
                principalTable: "tblSeller",
                principalColumn: "Username");
        }
    }
}
