
using System.Linq;
using System.Collections.Generic;

namespace ProcGen
{
	public class Energy : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.Energy; }

		public Appraisal Evaluate ( State currentState )
		{

			if ( currentState.AttemptingAction == ActionID.Eat ||
				 currentState.AttemptingAction == ActionID.Relax ||
				 currentState.AttemptingAction == ActionID.Sleep )
			{
				return new Appraisal()
				{
					BaseUtility = 1f - currentState.Utilities.Energy,
					Multiplier = 1f
				};
			}

			return new Appraisal()
			{
				BaseUtility = currentState.Utilities.Energy,
				Multiplier = 1f
			};
		}
	}
}