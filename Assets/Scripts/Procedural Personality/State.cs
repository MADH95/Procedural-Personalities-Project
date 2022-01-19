using System.Collections.Generic;

namespace ProcGen
{
	public struct State
	{
		public WeatherState WeatherConditions { get; set; }

		public float TimeOfDay { get; set; }

		public Personality Personality { get; set; }

		public Utilities Utilities { get; set; }

		public List<ITask> ActionHistory { get; set; }
	}
}