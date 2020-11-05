using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly CalculoImpostoContext _contexto;
        
        public Repositorio(CalculoImpostoContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Adiciona uma novo registro na base
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        public void Adicionar(T entity)
        {
            _contexto.Set<T>().Add(entity);
        }

        /// <summary>
        /// Apaga um registro da base
        /// </summary>
        /// <param name="entity">Entidade a ser removida</param>
        public void Deletar(T entity)
        {
            _contexto.Set<T>().Remove(entity);
        }

        /// <summary>
        /// Altera um registro da base
        /// </summary>
        /// <param name="entity">Entidade a ser alterada</param>
        public void Alterar(T entity)
        {
            _contexto.Entry(entity).State = EntityState.Modified;
            _contexto.Set<T>().Update(entity);
        }

        /// <summary>
        /// Retorna todos os registros de uma determinada entidade
        /// </summary>
        public IEnumerable<T> BuscarTodos()
        {
            return _contexto.Set<T>().AsEnumerable<T>();
        }
        
        /// <summary>
        /// Retorna registros de uma determinada entidade com filtro
        /// </summary>
        /// <param name="predicate">filtro a ser aplicado </param>
        /// <returns>Lista com os registroa das entidade</returns>
        public IEnumerable<T> BuscarComFiltro(Expression<Func<T, bool>> predicate)
        {
            return _contexto.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        /// <summary>
        /// Retorna um registro de uma determinada entidade 
        /// </summary>
        /// <param name="predicate">Filtro a ser aplicado</param>
        /// <returns>Registro encontrado</returns>
        public T BuscarRegistroID(Expression<Func<T, bool>> predicate)
        {
            return _contexto.Set<T>().SingleOrDefault(predicate);
        }
    }
}
