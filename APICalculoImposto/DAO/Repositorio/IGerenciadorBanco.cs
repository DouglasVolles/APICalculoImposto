using APICalculoImposto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Repositorio
{
    public interface IGerenciadorBanco
    {
        IRepositorio<Contribuinte> ContribuinteRepositorio { get; }
        void Commit();
    }
}
