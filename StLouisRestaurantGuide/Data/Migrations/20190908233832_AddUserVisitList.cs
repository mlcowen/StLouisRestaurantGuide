using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisRestaurantGuide.Data.Migrations
{
    public partial class AddUserVisitList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserVisitListId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserVisitLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ListName = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserVisitLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserVisitLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserVisitListId",
                table: "Restaurants",
                column: "UserVisitListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserVisitLists_UserId",
                table: "UserVisitLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_UserVisitLists_UserVisitListId",
                table: "Restaurants",
                column: "UserVisitListId",
                principalTable: "UserVisitLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_UserVisitLists_UserVisitListId",
                table: "Restaurants");

            migrationBuilder.DropTable(
                name: "UserVisitLists");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_UserVisitListId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UserVisitListId",
                table: "Restaurants");
        }
    }
}
