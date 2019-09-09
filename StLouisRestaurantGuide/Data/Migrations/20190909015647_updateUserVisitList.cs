using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisRestaurantGuide.Data.Migrations
{
    public partial class updateUserVisitList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_UserVisitLists_UserVisitListId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_UserVisitLists_AspNetUsers_UserId",
                table: "UserVisitLists");

            migrationBuilder.DropIndex(
                name: "IX_UserVisitLists_UserId",
                table: "UserVisitLists");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_UserVisitListId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ListName",
                table: "UserVisitLists");

            migrationBuilder.DropColumn(
                name: "UserVisitListId",
                table: "Restaurants");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserVisitLists",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "UserVisitLists",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "UserVisitLists",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "UserVisitLists");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserVisitLists",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "UserVisitLists",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ListName",
                table: "UserVisitLists",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserVisitListId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserVisitLists_UserId",
                table: "UserVisitLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserVisitListId",
                table: "Restaurants",
                column: "UserVisitListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_UserVisitLists_UserVisitListId",
                table: "Restaurants",
                column: "UserVisitListId",
                principalTable: "UserVisitLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserVisitLists_AspNetUsers_UserId",
                table: "UserVisitLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
