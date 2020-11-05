using APICalculoImposto.DAO.Repositorio;
using APICalculoImposto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Regras
{
    public class ContribuinteDao : IDisposable
    {
        GerenciadorBanco _gerenciador;
        public ContribuinteDao(GerenciadorBanco gerenciador)
        {
            _gerenciador = gerenciador;
        }
        public ContribuinteDao()
        {
            _gerenciador = new GerenciadorBanco();
        }

        public List<Contribuinte> BuscarOrdenados()
        {
            var contribuintes =_gerenciador.ContribuinteRepositorio.BuscarTodos();

            contribuintes = contribuintes.OrderByDescending(c => c.ValorImpostoRenda).ThenBy(c => c.Nome);

            return contribuintes.ToList();
        }

        /// <summary>
        /// Adiciona um novo contribuinte 
        /// </summary>
        /// <param name="contribuinte">Recebe os dados do novo contribuinte</param>
        public void Adicinar(Contribuinte contribuinte)
        {
            ValidarRepeticao(contribuinte);
            ValidarCPF(contribuinte);

            _gerenciador.ContribuinteRepositorio.Adicionar(contribuinte);
            _gerenciador.Commit();
        }
        public void Alterar(Contribuinte contribuinte)
        {
            _gerenciador.ContribuinteRepositorio.Alterar(contribuinte);
            _gerenciador.Commit();
        }

        /// <summary>
        /// Remove todos os conribuintes da base
        /// </summary>
        public void DeletarTodos()
        {
            var contribuintes = _gerenciador.ContribuinteRepositorio.BuscarTodos();

             foreach (var contribuinte in contribuintes)
             {
                _gerenciador.ContribuinteRepositorio.Deletar(contribuinte);
             }
             _gerenciador.Commit();
         }

        private void ValidarRepeticao(Contribuinte contribuinte)
        {
            using (var contexto = new CalculoImpostoContext())
            {
                if (contexto.Contribuintes.Where(p => p.CPF == contribuinte.CPF).FirstOrDefault() != null)
                    throw new Exception("Contribuinte já cadastrado");
            }
        }

        private void ValidarCPF(Contribuinte contribuinte)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            
            var cpf = contribuinte.CPF.Trim().Replace(".", "").Replace("-", "").Replace("/", ""); 
            
            if (cpf.Length != 11)
                throw new Exception("CPF precisa ter 11 posições");

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    throw new Exception("CPF inválido");

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (!cpf.EndsWith(digito))
                throw new Exception("CPF inválido");
        }
        public void Dispose()
        {
            _gerenciador.Dispose();
        }
    }
}
