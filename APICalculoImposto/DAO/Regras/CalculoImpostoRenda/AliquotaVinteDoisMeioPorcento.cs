using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Regras.CalculoImpostoRenda
{
    public class AliquotaVinteDoisMeioPorcento : IRegraAliquota
    {
        public decimal Calcular(decimal rendaLiquida)
        {
            return rendaLiquida * 0.225m;
        }
    }
}
