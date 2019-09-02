using Microsoft.EntityFrameworkCore.Migrations;

namespace StLouisRestaurantGuide.Data.Migrations
{
    public partial class changedCategoryRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRestaurants_Restaurants_RestaurantId",
                table: "CategoryRestaurants");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "CategoryRestaurants");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "CategoryRestaurants",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRestaurants_Restaurants_RestaurantId",
                table: "CategoryRestaurants",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryRestaurants_Restaurants_RestaurantId",
                table: "CategoryRestaurants");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "CategoryRestaurants",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "CategoryRestaurants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryRestaurants_Restaurants_RestaurantId",
                table: "CategoryRestaurants",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
