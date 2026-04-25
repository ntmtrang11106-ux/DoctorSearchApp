using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL_Tier.Migrations
{
    /// <inheritdoc />
    public partial class RefactorSync : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_User_UserId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Location_LocationId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_User_UserId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_User_UserId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Appointments_AppointmentId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Doctor_DoctorID",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Patient_PatientID",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "Article_Specialty");

            migrationBuilder.DropTable(
                name: "Doctor_Specialty");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Specialtie");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_AppointmentId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_ExperienceSummary",
                table: "Doctor");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_LocationId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "BHYT",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Blood_Type",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Medical_History",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ClinicAddress",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "ClinicName",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "WorkingTime",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "User",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "TimeSlots",
                newName: "WorkDate");

            migrationBuilder.RenameColumn(
                name: "PatientID",
                table: "Reviews",
                newName: "PatientId");

            migrationBuilder.RenameColumn(
                name: "DoctorID",
                table: "Reviews",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PatientID",
                table: "Reviews",
                newName: "IX_Reviews_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_DoctorID",
                table: "Reviews",
                newName: "IX_Reviews_DoctorId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Doctor",
                newName: "ConsultationFee");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Doctor",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "ExperienceSummary",
                table: "Doctor",
                newName: "ExperienceYears");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Active",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Residential_Address",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "User",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CCCD",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TimeSlots",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Open",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Trống");

            migrationBuilder.AddColumn<int>(
                name: "BookedCount",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TimeSlots",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "TimeSlots",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "TimeSlots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxAppointments",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "TimeSlots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "TimeSlots",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Reviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reviews",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reviews",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Patient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Patient",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "Patient",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactPhone",
                table: "Patient",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InsuranceCode",
                table: "Patient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Patient",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MedicalCode",
                table: "Patient",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Patient",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Biography",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Doctor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Doctor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Doctor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Doctor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Doctor",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "JoinDate",
                table: "Doctor",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LicenseNumber",
                table: "Doctor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotesInternal",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Doctor",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Doctor",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Pending",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Chờ duyệt");

            migrationBuilder.AddColumn<string>(
                name: "DepartmentNameSnapshot",
                table: "Appointments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorNameSnapshot",
                table: "Appointments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FeeSnapshot",
                table: "Appointments",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "Appointments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoomNameSnapshot",
                table: "Appointments",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Appointments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Admin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Admin",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Admin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoomName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Content",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    AuthorAdminId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Draft"),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    IsPinned = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Content", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Content_Admin_AuthorAdminId",
                        column: x => x.AuthorAdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Content_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_RoomId",
                table: "TimeSlots",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_WorkDate_DoctorId_RoomId",
                table: "TimeSlots",
                columns: new[] { "WorkDate", "DoctorId", "RoomId" });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_DepartmentId",
                table: "Doctor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_AuthorAdminId",
                table: "Content",
                column: "AuthorAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Content_ContentType_Status_DepartmentId",
                table: "Content",
                columns: new[] { "ContentType", "Status", "DepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Content_DepartmentId",
                table: "Content",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentName",
                table: "Department",
                column: "DepartmentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomCode",
                table: "Room",
                column: "RoomCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_User_UserId",
                table: "Admin",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_User_UserId",
                table: "Doctor",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_User_UserId",
                table: "Patient",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Doctor_DoctorId",
                table: "Reviews",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Patient_PatientId",
                table: "Reviews",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Room_RoomId",
                table: "TimeSlots",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admin_User_UserId",
                table: "Admin");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_Department_DepartmentId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctor_User_UserId",
                table: "Doctor");

            migrationBuilder.DropForeignKey(
                name: "FK_Patient_User_UserId",
                table: "Patient");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Doctor_DoctorId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Patient_PatientId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Room_RoomId",
                table: "TimeSlots");

            migrationBuilder.DropTable(
                name: "Content");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_RoomId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_WorkDate_DoctorId_RoomId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_Doctor_DepartmentId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "BookedCount",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "MaxAppointments",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "EmergencyContactPhone",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "InsuranceCode",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "MedicalCode",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Patient");

            migrationBuilder.DropColumn(
                name: "Biography",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "JoinDate",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "LicenseNumber",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "NotesInternal",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "DepartmentNameSnapshot",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorNameSnapshot",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "FeeSnapshot",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "RoomNameSnapshot",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "User",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "WorkDate",
                table: "TimeSlots",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Reviews",
                newName: "PatientID");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Reviews",
                newName: "DoctorID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_PatientId",
                table: "Reviews",
                newName: "IX_Reviews_PatientID");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_DoctorId",
                table: "Reviews",
                newName: "IX_Reviews_DoctorID");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Doctor",
                newName: "LocationId");

            migrationBuilder.RenameColumn(
                name: "ExperienceYears",
                table: "Doctor",
                newName: "ExperienceSummary");

            migrationBuilder.RenameColumn(
                name: "ConsultationFee",
                table: "Doctor",
                newName: "Price");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Active");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Residential_Address",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Picture",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CCCD",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "TimeSlots",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Trống",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Open");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BHYT",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Blood_Type",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Medical_History",
                table: "Patient",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClinicAddress",
                table: "Doctor",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClinicName",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkingTime",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Appointments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "Chờ duyệt",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldDefaultValue: "Pending");

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "Appointments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Views = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_User_AdminID",
                        column: x => x.AdminID,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialtie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialtie", x => x.Id);
                });

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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false),
                    CertificateCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CertificateImage = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Experience_Years = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor_Specialty", x => x.Id);
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
                name: "IX_Reviews_AppointmentId",
                table: "Reviews",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_ExperienceSummary",
                table: "Doctor",
                column: "ExperienceSummary");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_LocationId",
                table: "Doctor",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Specialty_SpecialtyId",
                table: "Article_Specialty",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AdminID",
                table: "Articles",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Specialty_DoctorId_SpecialtyId",
                table: "Doctor_Specialty",
                columns: new[] { "DoctorId", "SpecialtyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Specialty_SpecialtyId",
                table: "Doctor_Specialty",
                column: "SpecialtyId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Province",
                table: "Location",
                column: "Province");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Province_LocationName",
                table: "Location",
                columns: new[] { "Province", "LocationName" });

            migrationBuilder.AddForeignKey(
                name: "FK_Admin_User_UserId",
                table: "Admin",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_Location_LocationId",
                table: "Doctor",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctor_User_UserId",
                table: "Doctor",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patient_User_UserId",
                table: "Patient",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Appointments_AppointmentId",
                table: "Reviews",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Doctor_DoctorID",
                table: "Reviews",
                column: "DoctorID",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Patient_PatientID",
                table: "Reviews",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
