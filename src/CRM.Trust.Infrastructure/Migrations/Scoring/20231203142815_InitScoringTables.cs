using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CRM.Trust.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitScoringTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Scoring");

            migrationBuilder.CreateTable(
                name: "Scorings",
                schema: "Scoring",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scorings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoringOutputs",
                schema: "Scoring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScoringValue = table.Column<decimal>(type: "numeric", nullable: false),
                    CalculateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    ScoringId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoringOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoringOutputs_Scorings_ScoringId",
                        column: x => x.ScoringId,
                        principalSchema: "Scoring",
                        principalTable: "Scorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoringParameters",
                schema: "Scoring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "character varying(170)", maxLength: 170, nullable: true),
                    ScoringId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoringParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoringParameters_Scorings_ScoringId",
                        column: x => x.ScoringId,
                        principalSchema: "Scoring",
                        principalTable: "Scorings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoringParameterIntervals",
                schema: "Scoring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    MinValue = table.Column<int>(type: "integer", nullable: false),
                    MaxValue = table.Column<int>(type: "integer", nullable: false),
                    ScoringParameterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoringParameterIntervals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScoringParameterIntervals_ScoringParameters_ScoringParamete~",
                        column: x => x.ScoringParameterId,
                        principalSchema: "Scoring",
                        principalTable: "ScoringParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoringOutputs_ScoringId",
                schema: "Scoring",
                table: "ScoringOutputs",
                column: "ScoringId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoringParameterIntervals_ScoringParameterId",
                schema: "Scoring",
                table: "ScoringParameterIntervals",
                column: "ScoringParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoringParameters_ScoringId",
                schema: "Scoring",
                table: "ScoringParameters",
                column: "ScoringId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoringOutputs",
                schema: "Scoring");

            migrationBuilder.DropTable(
                name: "ScoringParameterIntervals",
                schema: "Scoring");

            migrationBuilder.DropTable(
                name: "ScoringParameters",
                schema: "Scoring");

            migrationBuilder.DropTable(
                name: "Scorings",
                schema: "Scoring");
        }
    }
}
