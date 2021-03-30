using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.Data.Entities
{
    public class ClassificacaoSetorial
    {
        [Key]
        public int Id { get; set; }
        public int IdDeSubEstacao { get; set; }
        public int IdSetor { get; set; }
        public int IdSegmento { get; set; }
        public Setor Setor { get; set; }
        public SubSetor SubSetor { get; set; }
        public Segmento Segmento { get; set; }
        public List<Empresas> Empresas { get; set; }
    }
}
