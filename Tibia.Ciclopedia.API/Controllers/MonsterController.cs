using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.DeleteMonster;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetAll;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.GetMonster.GetByName;
using ZstdSharp.Unsafe;

namespace Tibia.Ciclopedia.API.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]")]
	public class MonsterController:ControllerBase
	{

		private readonly IMediator _mediator;

		public MonsterController(IMediator mediator) => _mediator = mediator;


		[HttpPost]
		[Route("")]
		public async Task<IActionResult> Create([FromBody] CreateMonsterInput request)
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
			var result = await _mediator.Send(new GetAllMonsterInput());
			if (!result.IsValid)
			{
				return BadRequest(string.Join(", ", result.Errors));
			}
			return Ok(result);
		}


		[HttpGet]
		[Route("Name")]
		public async Task<IActionResult> GetByName([FromQuery]GetMonsterByNameInput request)
		{
			var result =  await _mediator.Send(request);
			if (!result.IsValid)
			{
				return BadRequest(string.Join(",", result.Errors));
			}
			return Ok(result);
			
		}

		[HttpDelete]
		[Route("")]
		public async Task<IActionResult> Delete([FromQuery] DeleteMonsterInput request)
		{
			var result = await _mediator.Send(request);
			if(!result.IsValid)
			{
				return BadRequest(string.Join(",", result.Errors));
			}
			return Ok(result);
		}

		[HttpPut]
		[Route("{id:guid}")]
		public int Update()
		{
			return 0;
		}

	}
}
