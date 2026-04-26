using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL_Tier.Migrations
{
    /// <inheritdoc />
    public partial class UpdateManyToManySearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Specialtie_SpecialtyId",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_SpecialtyId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Doctor");

            migrationBuilder.CreateTable(
                name: "Article_Specialty",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article_Specialty", x => new { x.ArticleId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK_Article_Specialty_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Article_Specialty_Specialtie_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialtie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor_Specialty",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_Specialty", x => new { x.DoctorId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK_Doctor_Specialty_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialty_Specialtie_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialtie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Specialty_SpecialtyId",
                table: "Article_Specialty",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Specialty_SpecialtyId",
                table: "Doctor_Specialty",
                column: "SpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article_Specialty");

            migrationBuilder.DropTable(
                name: "Doctor_Specialty");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecialtyId",
                table: "Doctor",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Specialtie_SpecialtyId",
                table: "Doctor",
                column: "SpecialtyId",
                principalTable: "Specialtie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
