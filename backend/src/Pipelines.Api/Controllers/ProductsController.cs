using Microsoft.AspNetCore.Mvc;
using Pipelines.Application.Contracts.Product;
using Pipelines.Domain.DomainEntities;
using Pipelines.Domain.Repositories;

namespace Pipelines.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        // Create AppService and AppQuery

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productRepository.GetAll().Select(x => ToDto(x)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entity = _productRepository.GetById(id);

            if (entity == null)
                return NotFound();

            return Ok(ToDto(entity));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductAddDto contract)
        {
            var entity = new ProductDomainEntity(contract.Name);
            _productRepository.Add(entity);
            _productRepository.UnitOfWork.Complete();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] Guid id, [FromBody] ProductAddDto contract)
        {
            var entity = new ProductDomainEntity(id, contract.Name);
            _productRepository.Update(entity);
            _productRepository.UnitOfWork.Complete();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _productRepository.Delete(id);
            _productRepository.UnitOfWork.Complete();

            return NoContent();
        }

        private static ProductDto ToDto(ProductDomainEntity entity)
        {
            return new ProductDto()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}
