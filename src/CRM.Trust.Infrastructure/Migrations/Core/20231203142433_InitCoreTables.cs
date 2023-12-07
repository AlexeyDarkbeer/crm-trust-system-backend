using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRM.Trust.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitCoreTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Core");

            migrationBuilder.CreateTable(
                name: "BusinessProcessesStageStatuses",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcessesStageStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LastName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    MiddleName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Gender = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcessesStages",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    BusinessProcessStageStatusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcessesStages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcessesStages_BusinessProcessesStageStatuses_Busi~",
                        column: x => x.BusinessProcessStageStatusId,
                        principalSchema: "Core",
                        principalTable: "BusinessProcessesStageStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                schema: "Core",
                columns: table => new
                {
                    LoanId = table.Column<string>(type: "text", nullable: false),
                    CreditType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Core",
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonAddresses",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    AddressType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonAddresses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Core",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonContacts",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonContacts_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Core",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonJobs",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CompanyName = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Position = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SalaryAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonJobs_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Core",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonPassports",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Series = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Number = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    IssuedBy = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DepartmentNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonPassports_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Core",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcesses",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    BusinessProcessStageId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcesses_BusinessProcessesStages_BusinessProcessSt~",
                        column: x => x.BusinessProcessStageId,
                        principalSchema: "Core",
                        principalTable: "BusinessProcessesStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessProcesses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalSchema: "Core",
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusinessProcessesStageTransitions",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FromStageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToStageId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessProcessesStageTransitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessProcessesStageTransitions_BusinessProcessesStages_F~",
                        column: x => x.FromStageId,
                        principalSchema: "Core",
                        principalTable: "BusinessProcessesStages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusinessProcessesStageTransitions_BusinessProcessesStages_T~",
                        column: x => x.ToStageId,
                        principalSchema: "Core",
                        principalTable: "BusinessProcessesStages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LoanPayments",
                schema: "Core",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LoanId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanPayments_Loans_LoanId",
                        column: x => x.LoanId,
                        principalSchema: "Core",
                        principalTable: "Loans",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcesses_BusinessProcessStageId",
                schema: "Core",
                table: "BusinessProcesses",
                column: "BusinessProcessStageId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcesses_PersonId",
                schema: "Core",
                table: "BusinessProcesses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessesStageTransitions_FromStageId",
                schema: "Core",
                table: "BusinessProcessesStageTransitions",
                column: "FromStageId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessesStageTransitions_ToStageId",
                schema: "Core",
                table: "BusinessProcessesStageTransitions",
                column: "ToStageId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinessProcessesStages_BusinessProcessStageStatusId",
                schema: "Core",
                table: "BusinessProcessesStages",
                column: "BusinessProcessStageStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanPayments_LoanId",
                schema: "Core",
                table: "LoanPayments",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_PersonId",
                schema: "Core",
                table: "Loans",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonAddresses_PersonId",
                schema: "Core",
                table: "PersonAddresses",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonContacts_PersonId",
                schema: "Core",
                table: "PersonContacts",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonJobs_PersonId",
                schema: "Core",
                table: "PersonJobs",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonPassports_PersonId",
                schema: "Core",
                table: "PersonPassports",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessProcesses",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "BusinessProcessesStageTransitions",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "LoanPayments",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PersonAddresses",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PersonContacts",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PersonJobs",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "PersonPassports",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "BusinessProcessesStages",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Loans",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "BusinessProcessesStageStatuses",
                schema: "Core");

            migrationBuilder.DropTable(
                name: "Persons",
                schema: "Core");
        }
    }
}
