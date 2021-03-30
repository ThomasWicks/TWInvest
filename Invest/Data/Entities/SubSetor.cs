﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Invest.Data.Entities
{
    public class SubSetor
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<ClassificacaoSetorial> ListaDeClassificacaoSetorial { get; set; }
    }
}
