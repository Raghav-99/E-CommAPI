using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class tblSeller_email_out : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "tblSeller");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "tblSeller",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");*/
        }
    }
}
