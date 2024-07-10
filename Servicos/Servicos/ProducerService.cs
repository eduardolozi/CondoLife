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
    public class ProducerService<T> where T : class
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

        public async Task EnviarMensagem(T objeto)
        {
            try
            {
                var objetoSerializado = JsonSerializer.Serialize(objeto);
                var mensagem = new Message<Null, string> { Value = objetoSerializado };
                await _producer.ProduceAsync(_parametros.TopicName, mensagem);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro ao enviar mensagem ao Broker do Kafka.", ex);
            }
        }
    }
}
