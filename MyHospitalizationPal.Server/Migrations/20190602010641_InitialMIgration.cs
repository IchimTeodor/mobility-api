using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyHospitalizationPal.Server.Migrations
{
    public partial class InitialMIgration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthProfessional",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Photo = table.Column<string>(maxLength: 50, nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Department = table.Column<string>(maxLength: 50, nullable: false),
                    Type = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    EmergencyPhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    ReviewMark = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthProfessional", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    Gender = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    BloodType = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    IsInsured = table.Column<bool>(nullable: false),
                    ProfilePicturePath = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoomNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailySchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<string>(maxLength: 20, nullable: false),
                    EndTime = table.Column<string>(maxLength: 20, nullable: false),
                    DayOfWeek = table.Column<string>(maxLength: 20, nullable: false),
                    HeathProfessionalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailySchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailySchedule_HealthProfessional",
                        column: x => x.HeathProfessionalId,
                        principalTable: "HealthProfessional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PatientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContact_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Encounter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Details = table.Column<string>(maxLength: 50, nullable: true),
                    DateOfHospitalization = table.Column<DateTime>(type: "datetime", nullable: false),
                    PatientID = table.Column<int>(nullable: false),
                    DateOfDischarge = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "((1))"),
                    BraceletTagId = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encounter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Encounter_Department",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Encounter_Patient",
                        column: x => x.PatientID,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Encounter_Room",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EncounterNote",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateOfDocumentation = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comment = table.Column<string>(maxLength: 50, nullable: true),
                    EncounterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncounterNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientNote_Encounter",
                        column: x => x.EncounterID,
                        principalTable: "Encounter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScheduledEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ScheduledDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: true),
                    Location = table.Column<string>(maxLength: 50, nullable: false),
                    SpecialNote = table.Column<string>(maxLength: 10, nullable: true),
                    IsSpecialNoteMandatory = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    AssignedHealthProfessionalD = table.Column<int>(nullable: false),
                    EncounterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledEvent_HealthProfessional",
                        column: x => x.AssignedHealthProfessionalD,
                        principalTable: "HealthProfessional",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledEvent_Encounter",
                        column: x => x.EncounterID,
                        principalTable: "Encounter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UniqueCodeId = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    NumberLoginAttempts = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    EncounterID = table.Column<int>(nullable: false),
                    DateOfExpiration = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_Encounter",
                        column: x => x.EncounterID,
                        principalTable: "Encounter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feeling",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<string>(unicode: false, maxLength: 5, nullable: false),
                    FeelingType = table.Column<string>(unicode: false, maxLength: 25, nullable: false),
                    EncounterNoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feeling_PatientNote",
                        column: x => x.EncounterNoteId,
                        principalTable: "EncounterNote",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailySchedule_HeathProfessionalId",
                table: "DailySchedule",
                column: "HeathProfessionalId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContact_PatientID",
                table: "EmergencyContact",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Encounter_DepartmentId",
                table: "Encounter",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Encounter_PatientID",
                table: "Encounter",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Encounter_RoomId",
                table: "Encounter",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_EncounterNote_EncounterID",
                table: "EncounterNote",
                column: "EncounterID");

            migrationBuilder.CreateIndex(
                name: "IX_Feeling_EncounterNoteId",
                table: "Feeling",
                column: "EncounterNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledEvent_AssignedHealthProfessionalD",
                table: "ScheduledEvent",
                column: "AssignedHealthProfessionalD");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledEvent_EncounterID",
                table: "ScheduledEvent",
                column: "EncounterID");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_EncounterID",
                table: "UserInfo",
                column: "EncounterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailySchedule");

            migrationBuilder.DropTable(
                name: "EmergencyContact");

            migrationBuilder.DropTable(
                name: "Feeling");

            migrationBuilder.DropTable(
                name: "ScheduledEvent");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "EncounterNote");

            migrationBuilder.DropTable(
                name: "HealthProfessional");

            migrationBuilder.DropTable(
                name: "Encounter");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}
