using System.Collections.Generic;

namespace ProcGen
{
	public class Mingle : Task
	{
		public override ActionID ID { get => ActionID.Mingle; }

		public override bool Perform ()
		{
			return false;
		}
	}
}
