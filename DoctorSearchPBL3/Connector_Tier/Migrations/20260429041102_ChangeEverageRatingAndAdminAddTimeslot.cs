using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL_Tier.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEverageRatingAndAdminAddTimeslot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByAdminId",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Doctor",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "TotalReviews",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_CreatedByAdminId",
                table: "TimeSlots",
                column: "CreatedByAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Admin_CreatedByAdminId",
                table: "TimeSlots",
                column: "CreatedByAdminId",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Admin_CreatedByAdminId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_CreatedByAdminId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "CreatedByAdminId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "TotalReviews",
                table: "Doctor");
        }
    }
}
