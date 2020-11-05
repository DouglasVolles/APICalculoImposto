using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using APICalculoImposto.DAO;
using APICalculoImposto.Models;
using APICalculoImposto.DAO.Regras;
using APICalculoImposto.DAO.Regras.CalculoImpostoRenda;
using Microsoft.AspNetCore.Authorization;

namespace APICalculoImposto.Controllers
{
       
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoImpostosController : ControllerBase
    {
        [HttpGet]
        public List<Contribuinte> Get()
        {
            CalculadorImpostoRenda.RealizarCalculo(100);
            using (var contribuinte = new ContribuinteDao())
            {
                var contribuintes = contribuinte.BuscarOrdenados();
                return contribuintes;
            }
            
        }
        
        [HttpPost]
        public string Adicionar(string cpf, string nome, string renda, string dependentes)
        {
            try
            {
                using (var contribuinte = new ContribuinteDao())
                {
                    contribuinte.Adicinar(new Contribuinte()
                    { Nome = nome, CPF = cpf, QuantidadeDependente = Convert.ToInt32(dependentes), RendaBruta = Convert.ToDecimal(renda) });
                }
                return "Contribuinte adicionado com sucesso!";
                //return new JsonResult(new { "Mensagem = Adicionado com sucesso!"});
            }
            catch (Exception erro)
            {
                return string.Format("Erro ao cadastrar o contribuinte:{0}",erro.Message);
                //return new JsonResult(new { Mensagem = erro.Message });
            }
        }

        [HttpDelete]
        public ActionResult<IEnumerable<string>> Delete()
        {
            using (var contribuinte = new ContribuinteDao())
            {
                contribuinte.DeletarTodos();
            }
            return StatusCode(200, "Removido com sucesso");
        }
    }
}
