using Confluent.Kafka;
using DesafioCB.Application.DTO.DTO;
using DesafioCB.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DesafioCB.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutosController(IApplicationServiceProduto ApplicationServiceProduto)

        {
            _applicationServiceProduto = ApplicationServiceProduto;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationServiceProduto.GetAll());
        }

        // GET api/values/5\
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationServiceProduto.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();


                _applicationServiceProduto.Add(produtoDTO);
                
                SendMessageByKafka(produtoDTO);
                
                return Ok("O produto foi cadastrado com sucesso");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {

            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Update(produtoDTO);
                return Ok("O produto foi atualizado com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Remove(produtoDTO);
                return Ok("O produto foi removido com sucesso!");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private IProducer<string, string> _kafkaProducer;
        private void SendMessageByKafka(ProdutoDTO produtoDTO)
        {

            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            _kafkaProducer = new ProducerBuilder<string, string>(config).Build();

            var message = new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = JsonSerializer.Serialize(produtoDTO) };
            _kafkaProducer.Produce("Estoque", message);
        }
    }
}
