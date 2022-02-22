using System.Collections.Generic;

namespace ProcGen
{
	public struct State
	{
		public float TimeOfDay { get; set; }

		public Personality Personality { get; set; }

		public Utilities Utilities { get; set; }

		public LinkedList<Task> ActionHistory { get; set; }

		public ActionID AttemptingAction { get; set; }
	}
}