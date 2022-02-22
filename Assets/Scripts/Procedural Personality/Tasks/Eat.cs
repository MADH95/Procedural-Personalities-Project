using System.Collections.Generic;

namespace ProcGen
{
	public class Eat : Task
	{
		public override ActionID ID { get => ActionID.Eat; }

		public override bool Perform ()
		{
			return false;
		}
	}
}