using MaxCoRetailManager.Application.DTOs.CategoryDTO;
using MaxCoRetailManager.Application.Features.Categories.Requests.Commands;
using MaxCoRetailManager.Application.Features.Categories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MaxCoRetailManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory([FromBody] CategoryCreateDto categoryCreateDto)
        {
            var createCategoryCommand = new CategoryCreateCommand() { CategoryCreateDto = categoryCreateDto };
            var response = await _mediator.Send(createCategoryCommand);
            return Ok(response);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory([FromBody] CategoryUpdateDto categoryUpdateDto)
        {
            var updateCategoryCommand = new CategoryUpdateCommand { CategoryUpdateDto = categoryUpdateDto };
            var response = await _mediator.Send(updateCategoryCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var getCategoriesQuery = new GetCategorysListQuery();
            var response = await _mediator.Send(getCategoriesQuery);
            return Ok(response);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var getCategoryByIdQuery = new GetCategoryByIdQuery() { Id = Id };
            var response = await _mediator.Send(getCategoryByIdQuery);
            return Ok(response);
        }
    }
}
