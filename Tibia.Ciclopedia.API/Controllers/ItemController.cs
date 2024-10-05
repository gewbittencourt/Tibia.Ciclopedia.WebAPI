using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tibia.Ciclopedia.Application.UseCases.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.DeleteItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName;
using Tibia.Ciclopedia.Application.UseCases.Update.UpdateItem;
using Tibia.Ciclopedia.Domain.Items;

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
			if (!result.IsValid)
			{
				return BadRequest(result.Errors.ToString());
			}
			return Ok(result);
		}

		[HttpGet]
		[Route("")]
		public async Task<IActionResult> GetAll()
		{
			var result = await _mediator.Send(new GetAllItemInput());
			if (!result.IsValid)
			{
				return BadRequest(result.Errors.ToString());
			}
			return Ok(result);
		}

		[HttpGet]
		[Route("Name")]
		public async Task<IActionResult> GetByName([FromQuery] GetByNameItemsInput request)
		{
			var result = await _mediator.Send(request);
			if (!result.IsValid)
			{
				return BadRequest(result.Errors.ToString());
			}
			return Ok(result);
		}


		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateItem([FromRoute] Guid id, [FromBody] UpdateItemInput request)
		{
			request.Id = id;
			var result = await _mediator.Send(request);
			if (!result.IsValid)
			{
				return BadRequest(result.Errors.ToString());
			}
			return Ok(result);
		}

		[HttpDelete]
		[Route("")]
		public async Task<IActionResult> Delete([FromQuery] DeleteItemInput request)
		{
			var result = await _mediator.Send(request);
			if (!result.IsValid)
			{
				return BadRequest(result.Errors.ToString());
			}
			return Ok(result);

		}


	}
}
