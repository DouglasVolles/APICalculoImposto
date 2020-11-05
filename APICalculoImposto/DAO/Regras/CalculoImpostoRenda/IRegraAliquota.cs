using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Regras.CalculoImpostoRenda
{
    public interface IRegraAliquota
    {      
        decimal Calcular(decimal rendaLiquida);
    }
}
