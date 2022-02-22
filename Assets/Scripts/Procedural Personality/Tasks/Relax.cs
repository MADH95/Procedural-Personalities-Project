using System.Linq;
using System.Collections.Generic;

namespace ProcGen
{
	public class Relax : Task
	{
		public override ActionID ID { get => ActionID.Relax; }

		public override bool Perform ()
		{
			return false;
		}
	}
}
