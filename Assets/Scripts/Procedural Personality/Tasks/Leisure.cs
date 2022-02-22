using System.Collections.Generic;

namespace ProcGen
{
	public class Leisure : Task
	{
		public override ActionID ID { get => ActionID.Leisure; }

		public override bool Perform ()
		{
			return false;
		}
	}
}
