using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Domain.Items.Enums
{
	[Flags]
	public enum Vocations
	{
		None = 0,
		Knight = 1,
		Paladin = 2,
		Druid = 4,
		Sorcerer = 8
	}
}
