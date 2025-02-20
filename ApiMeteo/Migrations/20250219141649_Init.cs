using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiMeteo.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    IDCity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NazionCity = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.IDCity);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    EmailUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.EmailUser);
                });

            migrationBuilder.CreateTable(
                name: "Preferences",
                columns: table => new
                {
                    EmailUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IDCity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences", x => new { x.EmailUser, x.IDCity });
                    table.ForeignKey(
                        name: "FK_Preferences_Cities_IDCity",
                        column: x => x.IDCity,
                        principalTable: "Cities",
                        principalColumn: "IDCity",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preferences_Users_EmailUser",
                        column: x => x.EmailUser,
                        principalTable: "Users",
                        principalColumn: "EmailUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_IDCity",
                table: "Preferences",
                column: "IDCity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preferences");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
