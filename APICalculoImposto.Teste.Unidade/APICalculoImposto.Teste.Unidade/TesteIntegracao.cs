using System;
using Xunit;
using APICalculoImposto.DAO.Regras;
using APICalculoImposto.Models;
using Microsoft.AspNetCore.Mvc;
using APICalculoImposto.DAO.Regras.CalculoImpostoRenda;
using System.Collections.Generic;

namespace APICalculoImposto.Teste.Unidade
{
    public class ModeloInformacao
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public decimal ValorImposto { get; set; }
    }
    public class TesteIntegracao
    {
        [Fact]
        public void TesteCompleto()
        {
            try
            {
                using (var contribuinte = new ContribuinteDao())
                {
                    contribuinte.DeletarTodos();
                    contribuinte.Adicinar(new Contribuinte()
                    { Nome = "Ana", CPF = "67041416003", QuantidadeDependente = 1, RendaBruta = 100, ValorSalarioMinino = 100 });
                    contribuinte.Adicinar(new Contribuinte()
                    { Nome = "Pedro", CPF = "15861948011", QuantidadeDependente = 0, RendaBruta = 200, ValorSalarioMinino = 100 });
                    contribuinte.Adicinar(new Contribuinte()
                    { Nome = "Douglas", CPF = "46137755070", QuantidadeDependente = 1, RendaBruta = 210, ValorSalarioMinino = 100 });
                    contribuinte.Adicinar(new Contribuinte()
                    { Nome = "Ana", CPF = "21255527013", QuantidadeDependente = 1, RendaBruta = 500, ValorSalarioMinino = 100 });
                    contribuinte.Adicinar(new Contribuinte()
                    { Nome = "Paulo", CPF = "65317973040", QuantidadeDependente = 1, RendaBruta = 600, ValorSalarioMinino = 100 });
                    contribuinte.Adicinar(new Contribuinte()
                    { Nome = "Douglas", CPF = "84664448074", QuantidadeDependente = 1, RendaBruta = 900, ValorSalarioMinino = 100 });
                    contribuinte.Adicinar(new Contribuinte()
                    { Nome = "Ana", CPF = "98965835011", QuantidadeDependente = 5, RendaBruta = 10000, ValorSalarioMinino = 100 });
                    CalculadorImpostoRenda.RealizarCalculo(100);
                }

                using (var contribuinte = new ContribuinteDao())
                {
                    var resultadosAguardados = BuscarResultados();

                    var contribuintes = contribuinte.BuscarOrdenados();

                    for (int i = 0; i < contribuintes.Count; i++)
                    {
                        validarInformacoes(contribuintes[i], resultadosAguardados[i]);
                    }

                }
                Assert.Equal("Sucesso", "Sucesso");

            }
            catch (Exception erro)
            {
                Assert.Equal("Sucesso", erro.Message);
            }
        }

        private void validarInformacoes(Contribuinte contribuinte, ModeloInformacao informacaoAguardada)
        {
            if (contribuinte.Nome != informacaoAguardada.Nome)
                throw new Exception(string.Format("Nome aguardado {0}, Nome Obtido {1}", informacaoAguardada.Nome, contribuinte.Nome));

            if (contribuinte.CPF != informacaoAguardada.CPF)
                throw new Exception(string.Format("CPF aguardado {0}, CPF Obtido {1}", informacaoAguardada.CPF, contribuinte.CPF));

            if (contribuinte.ValorImpostoRenda != informacaoAguardada.ValorImposto)
                throw new Exception(string.Format("Imposto aguardado {0}, Imposto Obtido {1}", informacaoAguardada.ValorImposto, contribuinte.ValorImpostoRenda));
        }

        private List<ModeloInformacao> BuscarResultados()
        {
            var resultados = new List<ModeloInformacao>();
            resultados.Add(new ModeloInformacao() { Nome = "Ana", CPF = "98965835011", ValorImposto = 2743.13M });
            resultados.Add(new ModeloInformacao() { Nome = "Douglas", CPF = "84664448074", ValorImposto = 246.13M});
            resultados.Add(new ModeloInformacao() { Nome = "Paulo", CPF = "65317973040", ValorImposto = 133.88M});
            resultados.Add(new ModeloInformacao() { Nome = "Ana", CPF = "21255527013", ValorImposto = 74.25M});
            resultados.Add(new ModeloInformacao() { Nome = "Douglas", CPF = "46137755070", ValorImposto = 15.38M});
            resultados.Add(new ModeloInformacao() { Nome = "Ana", CPF = "67041416003", ValorImposto = 0});
            resultados.Add(new ModeloInformacao() { Nome = "Pedro", CPF = "15861948011", ValorImposto = 0});

            return resultados;
        }
    }
}
