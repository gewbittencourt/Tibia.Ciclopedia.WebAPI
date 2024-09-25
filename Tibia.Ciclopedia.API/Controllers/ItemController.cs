using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tibia.Ciclopedia.Application.UseCases.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.DeleteItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName;
using Tibia.Ciclopedia.Application.UseCases.UpdateItem.UpdateAllItem;
using Tibia.Ciclopedia.Domain.Entities;
using Tibia.Ciclopedia.Domain.Interface;

namespace TibiaItem.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ItemController : ControllerBase
	{

		private readonly IMediator _mediator;

		public ItemController(IMediator mediator) => _mediator = mediator;


		[HttpPost]
		[Route("")]
		public async Task<IActionResult> Create([FromBody] CreateItemInput request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _mediator.Send(new GetAllItemInput());
			return Ok(result);
		}

		[HttpGet]
		[Route("Name")]
		public async Task<IActionResult> GetByName([FromQuery] GetByNameItemsInput request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}


		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateItem([FromRoute] Guid id, [FromBody] UpdateItemInput request)
		{
			request.id = id;
			var result = await _mediator.Send(request);
			return Ok(result);
		}

		[HttpDelete]
		[Route("")]
		public async Task<IActionResult> Delete([FromQuery] DeleteItemInput request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);

		}


	}
}
