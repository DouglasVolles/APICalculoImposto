using Microsoft.EntityFrameworkCore.Migrations;

namespace APICalculoImposto.Migrations
{
    public partial class Campo_Renda_QTD_Salario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "QuantidadeSalarios",
                table: "Contribuintes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RendaLiquida",
                table: "Contribuintes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorSalarioMinino",
                table: "Contribuintes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantidadeSalarios",
                table: "Contribuintes");

            migrationBuilder.DropColumn(
                name: "RendaLiquida",
                table: "Contribuintes");

            migrationBuilder.DropColumn(
                name: "ValorSalarioMinino",
                table: "Contribuintes");
        }
    }
}
