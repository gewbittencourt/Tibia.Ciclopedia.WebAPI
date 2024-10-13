﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibia.Ciclopedia.Application.BaseOutput;
using Tibia.Ciclopedia.Domain.Items;

namespace Tibia.Ciclopedia.Application.UseCases.GetItem.GetByName
{
	public class GetItemByNameInput : IRequest<Output<Item>>
	{
		public string Name { get; set; }
	}
}