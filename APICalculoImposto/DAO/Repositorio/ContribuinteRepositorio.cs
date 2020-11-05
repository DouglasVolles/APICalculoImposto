using APICalculoImposto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Repositorio
{
    public class ContribuinteRepositorio : IRepositorio<Contribuinte>
    {

        CalculoImpostoContext _contexto;

        public ContribuinteRepositorio(CalculoImpostoContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Contribuinte entity)
        {
            _contexto.Contribuintes.Add(entity);
        }

        public void Alterar(Contribuinte entity)
        {
            _contexto.Contribuintes.Update(entity);
        }

        public IEnumerable<Contribuinte> BuscarComFiltro(Expression<Func<Contribuinte, bool>> predicate)
        {
            return _contexto.Contribuintes.Where(predicate);
        }

        public Contribuinte BuscarRegistroID(Expression<Func<Contribuinte, bool>> predicate)
        {
            return _contexto.Contribuintes.FirstOrDefault(predicate);
        }

        public IEnumerable<Contribuinte> BuscarTodos()
        {
            return _contexto.Contribuintes.ToList();
        }

        public void Deletar(Contribuinte entity)
        {
            _contexto.Contribuintes.Remove(entity);
        }
    }
}
