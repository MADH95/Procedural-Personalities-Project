using System.Collections.Generic;

namespace ProcGen
{
	public interface ITask
	{
		public List<IConsideration> Considerations { get; set; }

		public bool IsRunning { get; set; }

		public float CalculateUtility ( ref State currentState );

		public void AddConsideration ( IConsideration consideration );

		public bool Perform ();
	}
}