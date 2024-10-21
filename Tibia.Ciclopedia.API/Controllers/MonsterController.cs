using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tibia.Ciclopedia.Application.UseCases.ItemUC.CreateItem;
using Tibia.Ciclopedia.Application.UseCases.MonsterUC.CreateMonster;

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
		public int GetAll()
		{
			return 0;
		}

		[HttpGet]
		[Route("Name")]
		public int GetByName()
		{
			return 0;
		}

		[HttpDelete]
		[Route("")]
		public int Delete()
		{
			return 0;
		}

		[HttpPut]
		[Route("{id:guid}")]
		public int Update()
		{
			return 0;
		}

	}
}
