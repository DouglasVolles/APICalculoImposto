using Microsoft.EntityFrameworkCore.Migrations;

namespace APICalculoImposto.Migrations
{
    public partial class Campo_Imposto_Renda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorImpostoRenda",
                table: "Contribuintes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorImpostoRenda",
                table: "Contribuintes");
        }
    }
}
