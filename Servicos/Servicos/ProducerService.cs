using Aplicacao.Parametros;
using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aplicacao.Servicos
{
    public class ProducerService
    {
        private readonly ProducerConfig _producerConfig;
        private readonly ParametrosKafka _parametros;
        private readonly IProducer<Null, string> _producer;
        public ProducerService() 
        {
            _parametros = new ParametrosKafka();
            _producerConfig = new ProducerConfig
            {
                BootstrapServers = _parametros.BootstrapServer,
            };
            _producer = new ProducerBuilder<Null, string>(_producerConfig).Build();
        }

        public async Task EnviarMensagem(string dados)
        {
            try
            {
                var mensagem = new Message<Null, string> { Value = dados };
                await _producer.ProduceAsync(_parametros.TopicName, mensagem);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao enviar mensagem ao Broker do Kafka.", ex);
            }
        }
    }
}
