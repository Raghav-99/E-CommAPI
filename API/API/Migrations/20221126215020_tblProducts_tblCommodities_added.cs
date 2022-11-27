using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class tblProducts_tblCommodities_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    PId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.PId);
                });

            migrationBuilder.CreateTable(
                name: "tblCommodities",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SellerModelUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PId = table.Column<int>(type: "int", nullable: false),
                    ProductsModelPId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCommodities", x => x.CId);
                    table.ForeignKey(
                        name: "FK_tblCommodities_tblProducts_ProductsModelPId",
                        column: x => x.ProductsModelPId,
                        principalTable: "tblProducts",
                        principalColumn: "PId");
                    table.ForeignKey(
                        name: "FK_tblCommodities_tblSeller_SellerModelUsername",
                        column: x => x.SellerModelUsername,
                        principalTable: "tblSeller",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCommodities_ProductsModelPId",
                table: "tblCommodities",
                column: "ProductsModelPId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCommodities_SellerModelUsername",
                table: "tblCommodities",
                column: "SellerModelUsername");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCommodities");

            migrationBuilder.DropTable(
                name: "tblProducts");
        }
    }
}
