using System.Collections.Generic;
using System.Linq;

namespace ProcGen
{
	public abstract class Task
	{
		public abstract ActionID ID { get; }

		public List<IConsideration> Considerations { get; set; }

		public bool CanChange { get; set; }

		public abstract float CalculateUtility ( State currentState );

		public abstract bool Perform();
	}
}