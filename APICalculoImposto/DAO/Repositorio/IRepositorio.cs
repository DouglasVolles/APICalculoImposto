using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Repositorio
{
    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> BuscarTodos();
        IEnumerable<T> BuscarComFiltro(Expression<Func<T, bool>> predicate);
        T BuscarRegistroID(Expression<Func<T, bool>> predicate);
        void Adicionar(T entity);
        void Deletar(T entity);
        void Alterar(T entity);
    }
}
