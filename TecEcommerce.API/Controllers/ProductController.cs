using Microsoft.AspNetCore.Mvc;
using TecEcommerce.Application.InputModels;
using TecEcommerce.Core.Entities;

namespace TecEcommerce.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // api/products
        /// <summary>
        /// Buscar todos os produtos
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        // api/products/1
        /// <summary>
        /// Buscar um produto por Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <response code="200">Success</response>
        /// <response code="404">Product not found</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        /// <summary>
        /// Cadastrar um produto
        /// </summary>
        /// <remarks>{
        /// "name": "Logitech G403", "description": "A great mouse gamer", "price": 129, "category": 1 }
        /// </remarks>
        /// <param name="model">Dados do produto</param>
        /// <returns>Produto cadastrado!</returns>
        /// <response code="201">Success</response>
        /// <response code="400">Bad request: invalid data</response>
        [HttpPost]
        public IActionResult Post([FromBody]ProductInputModel model)
        {
            var product = new Product(model.Name, model.Description, model.Price, model.Category);

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, model);
        }

        // api/products/2
        /// <summary>
        /// Atualizar um produto pelo seu Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Produto atualizado!</returns>
        /// <response code="204">Success</response>
        /// <response code="400">Bad request: invalid data</response>
        /// <response code="404">Product not found</response>
        [HttpPut("{id}")]
        public IActionResult Update(int id)
        {
            return NoContent();
        }

        /// <summary>
        /// Deletar um produto pelo seu Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Produto excluído!</returns>
        /// <response code="204">Success</response>
        /// <response code="404">Product not found</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
