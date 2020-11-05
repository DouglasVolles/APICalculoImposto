using APICalculoImposto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Repositorio
{
    public class GerenciadorBanco: IGerenciadorBanco, IDisposable
    {
        public CalculoImpostoContext _contexto;
        private Repositorio<Contribuinte> _clienteRepository;
        public GerenciadorBanco(CalculoImpostoContext context)
        {
            _contexto = context;
        }
        public GerenciadorBanco()
        {
            _contexto = new CalculoImpostoContext();
        }
        public IRepositorio<Contribuinte> ContribuinteRepositorio
        {
            get
            {
                return _clienteRepository = _clienteRepository ?? new Repositorio<Contribuinte>(_contexto);
            }
        }
        public void Commit()
        {
            _contexto.SaveChanges();
        }
        public void Dispose()
        {
            _contexto.Dispose();
        }

    }
}
