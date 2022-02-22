using System.Collections.Generic;
using System.Linq;

namespace ProcGen
{
	public abstract class Task
	{
		public abstract ActionID ID { get; }

		public List<IConsideration> Considerations { get; set; }

		public bool CanChange { get; set; }

		public float CalculateUtility ( State currentState )
		{
			List<Appraisal> appraisals = new List<Appraisal>( Considerations.Count );

			foreach ( var consideration in Considerations )
			{
				appraisals.Add( consideration.Evaluate( currentState ) );
			}

			float utility = appraisals.Aggregate( 0f, ( accum, elem ) => accum + elem.BaseUtility );

			return appraisals.Aggregate( utility, ( accum, elem ) => accum * elem.Multiplier );
		}

		public abstract bool Perform();
	}
}