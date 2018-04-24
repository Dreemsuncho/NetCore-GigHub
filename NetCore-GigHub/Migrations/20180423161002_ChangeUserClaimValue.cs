using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCoreGigHub.Migrations
{
    public partial class ChangeUserClaimValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ClaimValue",
                table: "Claims",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "ClaimValue",
                table: "Claims",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);
        }
    }
}
