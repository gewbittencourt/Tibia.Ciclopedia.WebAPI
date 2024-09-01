﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using TibiaItem.Application.UseCases.CreateItem;
using TibiaItem.Domain.Entities;
using TibiaItem.Domain.Interface;

namespace TibiaItem.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class ItemController : ControllerBase
	{

		private readonly IMediator _mediator;

		public ItemController(IMediator mediator) => _mediator = mediator;


		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateItemInput request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

	}
}
