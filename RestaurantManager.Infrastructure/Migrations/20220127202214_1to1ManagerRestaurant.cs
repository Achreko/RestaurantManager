using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantManager.Infrastructure.Migrations
{
    public partial class _1to1ManagerRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Restaurants_RestaurantId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_RestaurantId",
                table: "Managers");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Managers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Managers_RestaurantId",
                table: "Managers",
                column: "RestaurantId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Restaurants_RestaurantId",
                table: "Managers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Managers_Restaurants_RestaurantId",
                table: "Managers");

            migrationBuilder.DropIndex(
                name: "IX_Managers_RestaurantId",
                table: "Managers");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Managers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_RestaurantId",
                table: "Managers",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Managers_Restaurants_RestaurantId",
                table: "Managers",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
