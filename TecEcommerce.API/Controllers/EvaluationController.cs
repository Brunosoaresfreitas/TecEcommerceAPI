using Microsoft.AspNetCore.Mvc;
using TecEcommerce.Application.InputModels;
using TecEcommerce.Core.Entities;
using TecEcommerce.Core.Repositories;

namespace TecEcommerce.API.Controllers
{
    [Route("api/products/{id}/evaluations")]
    [ApiController]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationController(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        /// <summary>
        /// Buscar todas as avaliações de um determinado produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <response code="200">Success</response>
        /// <response code="404">Product Not Found</response>
        [HttpGet]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var evaluations = await _evaluationRepository.GetAllEvaluationByProductAsync(id);

            return Ok(evaluations);
        }

        /// <summary>
        /// Buscar uma avaliação específica de um produto
        /// </summary>
        /// <param name="id">Id do Produto</param>
        /// <param name="evaluationId">Id da avaliação</param>
        /// <response code="200">Success</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{evaluationId}")]
        public async Task<IActionResult> GetById(Guid id, Guid evaluationId)
        {
            var evaluation = await _evaluationRepository.GetEvaluationByIdAsync(evaluationId);

            if (evaluation == null) return NotFound();

            return Ok(evaluation);
        }

        /// <summary>
        /// Cadastrar uma avaliação em um produto
        /// </summary>
        /// <param name="id">Id do produto a ser avaliado</param>
        /// <param name="model">Dados da avaliação</param>
        /// <returns>Avaliação cadastrada!</returns>
        /// <response code="201">Success</response>
        /// <response code="400">Bad request: invalid data</response>
        [HttpPost]
        public async Task<IActionResult> Post(Guid id, EvaluationInputModel model)
        {
            var evaluation = new Evaluation(model.Evalution, model.Comment, id);

            await _evaluationRepository.CreateEvaluationAsync(evaluation);
            await _evaluationRepository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = evaluation.Id, evaluationId = evaluation.Id }, model);
        }
    }
}
