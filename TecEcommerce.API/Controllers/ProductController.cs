using Microsoft.AspNetCore.Mvc;
using TecEcommerce.Application.InputModels;
using TecEcommerce.Application.ViewModels;
using TecEcommerce.Core.Entities;
using TecEcommerce.Core.Repositories;

namespace TecEcommerce.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // api/products
        /// <summary>
        /// Buscar todos os produtos
        /// </summary>
        /// <response code="200">Success</response>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productRepository.GetAllAsync();

            if (products == null) return null;

            var productsViewModel = products
                .Select(p => new ProductViewModel(p.Id ,p.Name, p.Description, p.Price, p.Category))
                .ToList();

            return Ok(productsViewModel);
        }

        // api/products/1
        /// <summary>
        /// Buscar detalhadamente um produto por Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <response code="200">Success</response>
        /// <response code="404">Product not found</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
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
        public async Task<IActionResult> Post([FromBody] ProductInputModel model)
        {
            var product = new Product(model.Name, model.Description, model.Price, model.Category);

            await _productRepository.CreateProductAsync(product);
            await _productRepository.SaveChangesAsync();

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
        public async Task<IActionResult> Update(Guid id, [FromBody] ProductInputModel model)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null) return null;

            product.Update(model.Name, model.Description, model.Price, model.Category);
            await _productRepository.SaveChangesAsync();

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
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            if (product == null) return null;

            await _productRepository.DeleteProductAsync(product);
            await _productRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
