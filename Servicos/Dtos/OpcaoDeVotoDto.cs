﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Dtos
{
    public class OpcaoDeVotoDto
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public int VotacaoId { get; set; }
    }
}
