using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class tblCommodities_fk_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblProducts_ProductsModelPId",
                table: "tblCommodities");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblSeller_SellerModelUsername",
                table: "tblCommodities");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "tblCommodities");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "tblCommodities");

            migrationBuilder.RenameColumn(
                name: "SellerModelUsername",
                table: "tblCommodities",
                newName: "SellerUsername");

            migrationBuilder.RenameColumn(
                name: "ProductsModelPId",
                table: "tblCommodities",
                newName: "ProductPId");

            migrationBuilder.RenameIndex(
                name: "IX_tblCommodities_SellerModelUsername",
                table: "tblCommodities",
                newName: "IX_tblCommodities_SellerUsername");

            migrationBuilder.RenameIndex(
                name: "IX_tblCommodities_ProductsModelPId",
                table: "tblCommodities",
                newName: "IX_tblCommodities_ProductPId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblProducts_ProductPId",
                table: "tblCommodities");

            migrationBuilder.DropForeignKey(
                name: "FK_tblCommodities_tblSeller_SellerUsername",
                table: "tblCommodities");

            migrationBuilder.RenameColumn(
                name: "SellerUsername",
                table: "tblCommodities",
                newName: "SellerModelUsername");

            migrationBuilder.RenameColumn(
                name: "ProductPId",
                table: "tblCommodities",
                newName: "ProductsModelPId");

            migrationBuilder.RenameIndex(
                name: "IX_tblCommodities_SellerUsername",
                table: "tblCommodities",
                newName: "IX_tblCommodities_SellerModelUsername");

            migrationBuilder.RenameIndex(
                name: "IX_tblCommodities_ProductPId",
                table: "tblCommodities",
                newName: "IX_tblCommodities_ProductsModelPId");

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
