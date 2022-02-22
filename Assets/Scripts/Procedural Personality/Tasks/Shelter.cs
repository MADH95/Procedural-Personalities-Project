using System.Collections.Generic;

namespace ProcGen
{
	public class Shelter : Task
	{
		public override ActionID ID { get => ActionID.Shelter; }

		public override bool Perform ()
		{
			return false;
		}
	}
}
