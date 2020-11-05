using System;
using Xunit;
using APICalculoImposto.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace APICalculoImposto.Teste.Unidade
{
    public class CalculoImposto
    {
        [Fact]
        public void AAA_RemoveTodosContriuintes()
        {
            // setup
            var controller = new CalculoImpostosController();

            // ação
            var resultado = controller.Delete();

            // validações
            Assert.Equal("Removido com sucesso", (resultado.Result as ObjectResult).Value);
        }

        [Fact]
        public void AA_CadastraContribuinteCPFInválido()
        {
            // setup
            var controller = new CalculoImpostosController();

            // ação
            var resultado = (controller.Adicionar("050", "volles", "100", "1"));

            // validações
            Assert.Equal("Erro ao cadastrar o contribuinte:CPF precisa ter 11 posições", resultado);
        }

        [Fact]
        public void A_CadastraContribuinteCPFInválido()
        {
            // setup
            var controller = new CalculoImpostosController();

            // ação
            var resultado = (controller.Adicionar("05026862941", "volles", "100", "1"));

            // validações
            Assert.Equal("Erro ao cadastrar o contribuinte:CPF inválido", resultado);
        }

        [Fact] public void B_CadastraContribuinte()
        {
            // setup
            var controller = new CalculoImpostosController();

            // ação
            var resultado = (controller.Adicionar("05026862942", "volles", "100", "1"));

            // validações
            Assert.Equal("Contribuinte adicionado com sucesso!", resultado);
        }

        [Fact]
        public void C_CadastraContribuinteRepetido()
        {
            // setup
            var controller = new CalculoImpostosController();

            // ação
            var resultado = (controller.Adicionar("05026862942", "volles", "100", "1"));

            // validações
            Assert.Equal("Erro ao cadastrar o contribuinte:Contribuinte já cadastrado", resultado);
        }        
    }
}
