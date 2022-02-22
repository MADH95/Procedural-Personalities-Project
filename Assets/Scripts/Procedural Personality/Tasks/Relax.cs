using System.Linq;
using System.Collections.Generic;

namespace ProcGen
{
	public class Relax : Task
	{
		public override ActionID ID { get => ActionID.Relax; }

		public override float CalculateUtility ( State currentState )
		{
			List<Appraisal> appraisals = new List<Appraisal>( Considerations.Count );

			foreach ( var consideration in Considerations )
			{
				appraisals.Add( consideration.Evaluate( currentState ) );
			}

			float utility = appraisals.Aggregate( 0f, ( accum, elem ) => accum + elem.BaseUtility );

			return appraisals.Aggregate( utility, ( accum, elem ) => accum * elem.Multiplier );
		}

		public override bool Perform ()
		{
			return false;
		}
	}
}
