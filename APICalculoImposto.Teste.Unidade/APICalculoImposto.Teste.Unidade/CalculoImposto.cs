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

            // a��o
            var resultado = controller.Delete();

            // valida��es
            Assert.Equal("Removido com sucesso", (resultado.Result as ObjectResult).Value);
        }

        [Fact]
        public void AA_CadastraContribuinteCPFInv�lido()
        {
            // setup
            var controller = new CalculoImpostosController();

            // a��o
            var resultado = (controller.Adicionar("050", "volles", "100", "1"));

            // valida��es
            Assert.Equal("Erro ao cadastrar o contribuinte:CPF precisa ter 11 posi��es", resultado);
        }

        [Fact]
        public void A_CadastraContribuinteCPFInv�lido()
        {
            // setup
            var controller = new CalculoImpostosController();

            // a��o
            var resultado = (controller.Adicionar("05026862941", "volles", "100", "1"));

            // valida��es
            Assert.Equal("Erro ao cadastrar o contribuinte:CPF inv�lido", resultado);
        }

        [Fact] public void B_CadastraContribuinte()
        {
            // setup
            var controller = new CalculoImpostosController();

            // a��o
            var resultado = (controller.Adicionar("05026862942", "volles", "100", "1"));

            // valida��es
            Assert.Equal("Contribuinte adicionado com sucesso!", resultado);
        }

        [Fact]
        public void C_CadastraContribuinteRepetido()
        {
            // setup
            var controller = new CalculoImpostosController();

            // a��o
            var resultado = (controller.Adicionar("05026862942", "volles", "100", "1"));

            // valida��es
            Assert.Equal("Erro ao cadastrar o contribuinte:Contribuinte j� cadastrado", resultado);
        }        
    }
}
