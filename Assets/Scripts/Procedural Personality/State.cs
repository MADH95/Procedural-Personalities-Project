using System.Collections.Generic;

namespace ProcGen
{
	public struct State
	{
		public Personality Personality { get; set; }

		public Utilities Utilities { get; set; }

		public List<Task> ActionHistory { get; set; }

		public ActionID AttemptingAction { get; set; }
	}
}