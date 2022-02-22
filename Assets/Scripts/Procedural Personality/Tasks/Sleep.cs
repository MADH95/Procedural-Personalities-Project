using System.Collections.Generic;

namespace ProcGen
{
	public class Sleep : Task
	{
		public override ActionID ID { get => ActionID.Sleep; }

		public override bool Perform ()
		{
			return false;
		}
	}
}
