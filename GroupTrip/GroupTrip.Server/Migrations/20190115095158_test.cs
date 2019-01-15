using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupTrip.Server.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "PersonDbSet",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonDbSet_GroupId1",
                table: "PersonDbSet",
                column: "GroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDbSet_GroupDbSet_GroupId1",
                table: "PersonDbSet",
                column: "GroupId1",
                principalTable: "GroupDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonDbSet_GroupDbSet_GroupId1",
                table: "PersonDbSet");

            migrationBuilder.DropIndex(
                name: "IX_PersonDbSet_GroupId1",
                table: "PersonDbSet");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "PersonDbSet");
        }
    }
}
