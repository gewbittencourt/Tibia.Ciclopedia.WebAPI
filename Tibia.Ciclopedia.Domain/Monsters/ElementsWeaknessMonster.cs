using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tibia.Ciclopedia.Domain.Monsters
{
	public class ElementsWeaknessMonster
	{
		public int Physical {  get; private set; }
		public int Earth {  get; private set; }
		public int Fire {  get; private set; }
		public int Death {  get; private set; }
		public int Ice {  get; private set; }
		public int Energy {  get; private set; }
		public int Holy { get; private set; }

		public ElementsWeaknessMonster(int physical, int earth, int fire, int death, int ice, int energy, int holy)
		{
			Physical = physical;
			Earth = earth;
			Fire = fire;
			Death = death;
			Ice = ice;
			Energy = energy;
			Holy = holy;
		}
	}
}
