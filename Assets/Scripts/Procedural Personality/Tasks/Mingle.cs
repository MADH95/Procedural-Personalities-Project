using System.Collections.Generic;

namespace ProcGen
{
	public class Mingle : ITask
	{
		public List<IConsideration> Considerations { get; set; }
		public bool IsRunning { get; set; }

		public void AddConsideration ( IConsideration consideration )
		{

		}

		public float CalculateUtility ( ref State currentState )
		{
			return 0f;
		}

		public bool Perform ()
		{
			return false;
		}
	}
}
