using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GroupTrip.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TripDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDbSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupDbSet_TripDbSet_TripId",
                        column: x => x.TripId,
                        principalTable: "TripDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDbSet_GroupDbSet_GroupId",
                        column: x => x.GroupId,
                        principalTable: "GroupDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDbSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<double>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDbSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDbSet_PersonDbSet_PersonId",
                        column: x => x.PersonId,
                        principalTable: "PersonDbSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupDbSet_TripId",
                table: "GroupDbSet",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDbSet_PersonId",
                table: "PaymentDbSet",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDbSet_GroupId",
                table: "PersonDbSet",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentDbSet");

            migrationBuilder.DropTable(
                name: "PersonDbSet");

            migrationBuilder.DropTable(
                name: "GroupDbSet");

            migrationBuilder.DropTable(
                name: "TripDbSet");
        }
    }
}
