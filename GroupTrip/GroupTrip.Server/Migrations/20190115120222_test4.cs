using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupTrip.Server.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupDbSet_TripDbSet_TripId",
                table: "GroupDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentDbSet_PersonDbSet_PersonId",
                table: "PaymentDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDbSet_GroupDbSet_GroupId",
                table: "PersonDbSet");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDbSet_GroupDbSet_GroupId1",
                table: "PersonDbSet");

            migrationBuilder.DropIndex(
                name: "IX_PersonDbSet_GroupId",
                table: "PersonDbSet");

            migrationBuilder.DropIndex(
                name: "IX_PersonDbSet_GroupId1",
                table: "PersonDbSet");

            migrationBuilder.DropIndex(
                name: "IX_PaymentDbSet_PersonId",
                table: "PaymentDbSet");

            migrationBuilder.DropIndex(
                name: "IX_GroupDbSet_TripId",
                table: "GroupDbSet");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "PersonDbSet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "PersonDbSet",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonDbSet_GroupId",
                table: "PersonDbSet",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDbSet_GroupId1",
                table: "PersonDbSet",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDbSet_PersonId",
                table: "PaymentDbSet",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupDbSet_TripId",
                table: "GroupDbSet",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupDbSet_TripDbSet_TripId",
                table: "GroupDbSet",
                column: "TripId",
                principalTable: "TripDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentDbSet_PersonDbSet_PersonId",
                table: "PaymentDbSet",
                column: "PersonId",
                principalTable: "PersonDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDbSet_GroupDbSet_GroupId",
                table: "PersonDbSet",
                column: "GroupId",
                principalTable: "GroupDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDbSet_GroupDbSet_GroupId1",
                table: "PersonDbSet",
                column: "GroupId1",
                principalTable: "GroupDbSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
