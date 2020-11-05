using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace APICalculoImposto.DAO.Regras.CalculoImpostoRenda
{
    public class CalculadorImpostoFactory
    {
        public static IRegraAliquota CreateInstance(decimal quantidadeSalarios)
        {
            if (quantidadeSalarios <= 2)
                return new AliquotaIsento();
            else if (quantidadeSalarios > 2 && quantidadeSalarios <= 4)
                return new AliquotaSeteMeioPorcento();
            else if (quantidadeSalarios > 4 && quantidadeSalarios <= 5)
                return new AliquotaQuinzePorcento();
            else if (quantidadeSalarios > 5 && quantidadeSalarios <= 7)
                return new AliquotaVinteDoisMeioPorcento();
            else
                return new AliquotaVinteSeteMeioPorcento();
        }
    }
}
