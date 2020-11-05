using APICalculoImposto.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Regras.CalculoImpostoRenda
{
    public class CalculadorRenda
    {

        public static void Calcular(Contribuinte contribuinte, decimal salarioMinimo)
        {          
            contribuinte.ValorSalarioMinino = salarioMinimo;
            contribuinte.RendaLiquida = CalcularRendaMinima(contribuinte.RendaBruta, contribuinte.QuantidadeDependente, salarioMinimo);
            contribuinte.QuantidadeSalarios = (contribuinte.RendaLiquida / salarioMinimo);
        }

        private static decimal CalcularRendaMinima(decimal rendaBruta, int quantidadeDependentes, decimal salarioMinimo)
        {
            return rendaBruta - (salarioMinimo * (quantidadeDependentes * 0.05m));
        }
    }
}
