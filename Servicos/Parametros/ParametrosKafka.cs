using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacao.Parametros
{
    public class ParametrosKafka
    {
        public string BootstrapServer = "localhost:9092";
        public string TopicName = "votacoes";
        public string GroupId = "grupo-1";
    }
}
