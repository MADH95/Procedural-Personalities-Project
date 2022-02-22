using System.Collections.Generic;

namespace ProcGen
{
	public class Work : Task
	{
		public override ActionID ID { get => ActionID.Work; }

		public override bool Perform ()
		{
			return false;
		}
	}
}
