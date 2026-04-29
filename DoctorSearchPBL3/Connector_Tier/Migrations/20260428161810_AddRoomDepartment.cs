using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL_Tier.Migrations
{
    /// <inheritdoc />
    public partial class AddRoomDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Room",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Room_DepartmentId_RoomCode",
                table: "Room",
                columns: new[] { "DepartmentId", "RoomCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Department_DepartmentId",
                table: "Room",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_Department_DepartmentId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_DepartmentId_RoomCode",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Room");
        }
    }
}
