using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Automovil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fabricacion = table.Column<int>(type: "int", nullable: false),
                    NumeroMotor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroChasis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoInterno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutomovilPropertyOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutomovilPropertyTwo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automovil", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automovil");
        }
    }
}
