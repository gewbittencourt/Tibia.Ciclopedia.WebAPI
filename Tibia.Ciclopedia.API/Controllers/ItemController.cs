﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetAll;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.DeleteItem;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.GetItem.GetByName;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.UpdateItem;
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
				return BadRequest(string.Join(", ", result.Errors));
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
				return BadRequest(string.Join(", ", result.Errors));
			}
			return Ok(result);
		}

		[HttpGet]
		[Route("Name")]
		public async Task<IActionResult> GetByName([FromQuery] GetItemByNameInput request)
		{
			var result = await _mediator.Send(request);
			if (!result.IsValid)
			{
				return BadRequest(string.Join(", ", result.Errors));
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
				return BadRequest(string.Join(", ", result.Errors));
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
				return BadRequest(string.Join(", ", result.Errors));
			}
			return Ok(result);

		}


	}
}
