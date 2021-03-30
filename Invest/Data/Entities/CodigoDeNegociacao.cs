using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.Data.Entities
{
    public class CodigoDeNegociacao
    {
        [Key]
        public int Id { get; set; }
        public string TICKER { get; set; }
        public int CODIGO_CVM { get; set; }
        public Empresas Empresas { get; set; }
    }
}
