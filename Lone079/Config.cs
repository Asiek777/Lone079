using Exiled.API.Interfaces;

namespace Lone079
{
	public class Config : IConfig
	{
		public bool IsEnabled { get; set; } = true;

		public bool CountZombies { get; set; } = false;
		public int HealthBuffPerLevel { get; set; } = 10;
		public int HealthLossPerActivatedGenerator { get; set; } = 20;

		public int HealthPercent { get; set; } = 50;
	}
}
