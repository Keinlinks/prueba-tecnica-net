using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clients.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                        name: "IX_Clients_CountryId",
                        table: "Clients",
                        column: "CountryId");

            migrationBuilder.Sql(@"
                IF OBJECT_ID('dbo.GetClients', 'P') IS NULL
                BEGIN
                    EXEC('
                        CREATE PROCEDURE dbo.GetClients
                            @Page INT,
                            @PageSize INT
                        AS
                        BEGIN
                            SELECT CAST(c.Id AS NVARCHAR(36)) AS Id, c.Name, c.Phone, c.CountryId, co.Name AS Country
                            FROM Clients c
                            INNER JOIN Countries co ON c.CountryId = co.Id
                            ORDER BY c.Name
                            OFFSET (@Page - 1) * @PageSize ROWS
                            FETCH NEXT @PageSize ROWS ONLY;
                        END
                    ')
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
