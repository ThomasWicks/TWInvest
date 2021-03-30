using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.Data.Entities
{
    public class Empresas
    {
        [Key]
        public int CODIGO_CVM { get; set; }
        public string CNPJ { get; set; }
        public string NOME_FANTASIA { get; set; }
        public string NOME_PREGAO { get; set; }
        public string TIPO_PARTICIPANTE { get; set; }
        public string SITUACAO { get; set; }
        public DateTime DATA_STATUS { get; set; }
        public string CODIGO_LISTAGEM { get; set; }
        public int ID_ClASSIFICACAO_SETORIAL { get; set; }
        public ClassificacaoSetorial ClassificacaoSetorial { get; set; }
        public List<CodigoDeNegociacao> ListaDeCodigoDeNegociacao { get; set; }
    }
}
