using APICalculoImposto.DAO.Repositorio;
using APICalculoImposto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Regras.CalculoImpostoRenda
{
    public class CalculadorImpostoRenda
    {
        public static void RealizarCalculo(decimal salarioMinimo)
        {            
            var contribuintes = new GerenciadorBanco().ContribuinteRepositorio.BuscarTodos();

            foreach (var contribuinte in contribuintes)
            {

                CalculadorRenda.Calcular(contribuinte, salarioMinimo);
                contribuinte.ValorImpostoRenda = CalculadorImpostoFactory.
                                                 CreateInstance(contribuinte.QuantidadeSalarios).
                                                 Calcular(contribuinte.RendaLiquida);

                using (var contribuinteEdicao = new ContribuinteDao())
                {
                    contribuinteEdicao.Alterar(contribuinte);
                }
            }       
        }
    }
}
