using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class tblSeller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblSeller",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShopName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ShopRegNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductDetails = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSeller", x => x.Username);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblSeller");
        }
    }
}
