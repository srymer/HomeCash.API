using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HomeCash.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "dictionary");

            migrationBuilder.CreateTable(
                name: "HomeBases",
                schema: "dbo",
                columns: table => new
                {
                    Id_HomeBase = table.Column<Guid>(nullable: false),
                    HomeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_HomeBase", x => x.Id_HomeBase);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                schema: "dictionary",
                columns: table => new
                {
                    Id_Shop = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_Shop", x => x.Id_Shop);
                });

            migrationBuilder.CreateTable(
                name: "Costs",
                schema: "dbo",
                columns: table => new
                {
                    Id_Cost = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Vid_GeneratedByUser = table.Column<Guid>(nullable: false),
                    Vid_CreatedByUser = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Vid_HomeBase = table.Column<Guid>(nullable: false),
                    Vid_Shop = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_Cost", x => x.Id_Cost);
                    table.ForeignKey(
                        name: "Fid_HomeBase_FK2",
                        column: x => x.Vid_HomeBase,
                        principalSchema: "dbo",
                        principalTable: "HomeBases",
                        principalColumn: "Id_HomeBase",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                schema: "dbo",
                columns: table => new
                {
                    Id_Income = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Vid_GeneratedByUser = table.Column<Guid>(nullable: false),
                    Vid_CreatedByUser = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Vid_HomeBase = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_Income", x => x.Id_Income);
                    table.ForeignKey(
                        name: "Fid_HomeBase_FK3",
                        column: x => x.Vid_HomeBase,
                        principalSchema: "dbo",
                        principalTable: "HomeBases",
                        principalColumn: "Id_HomeBase",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id_User = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    PasswordSalt = table.Column<byte[]>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    HomeBaseId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_User", x => x.Id_User);
                    table.ForeignKey(
                        name: "Fid_HomeBase_FK1",
                        column: x => x.HomeBaseId,
                        principalSchema: "dbo",
                        principalTable: "HomeBases",
                        principalColumn: "Id_HomeBase",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_Vid_HomeBase",
                schema: "dbo",
                table: "Costs",
                column: "Vid_HomeBase");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_Vid_HomeBase",
                schema: "dbo",
                table: "Incomes",
                column: "Vid_HomeBase");

            migrationBuilder.CreateIndex(
                name: "IX_Users_HomeBaseId",
                schema: "dbo",
                table: "Users",
                column: "HomeBaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Costs",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Incomes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Shops",
                schema: "dictionary");

            migrationBuilder.DropTable(
                name: "HomeBases",
                schema: "dbo");
        }
    }
}
