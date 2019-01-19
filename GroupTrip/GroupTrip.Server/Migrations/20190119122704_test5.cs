using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupTrip.Server.Migrations
{
    public partial class test5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PaymentDbSet",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "PaymentDbSet",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "PaymentDbSet");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "PaymentDbSet",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
