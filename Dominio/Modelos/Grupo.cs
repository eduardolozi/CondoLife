using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelos
{
    public class Grupo
    {
        public int Id { get; set; }
        public string NomeDoCondominio { get; set; }
        public string? LinkDeConvite { get; set; }
    }
}
