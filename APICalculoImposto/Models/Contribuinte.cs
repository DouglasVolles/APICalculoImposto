using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICalculoImposto.Models
{
    public class Contribuinte
    {
        public int Id { get; internal set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public int QuantidadeDependente { get; set; }
        public decimal RendaBruta { get; set; }
        
        public decimal RendaLiquida { get; internal set; }

        public decimal ValorSalarioMinino { get; set; }

        public decimal ValorImpostoRenda { get; internal set; }

        public decimal QuantidadeSalarios { get; internal set; }

    }
}
