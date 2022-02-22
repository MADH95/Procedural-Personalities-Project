
using System.Linq;
using System.Collections.Generic;

namespace ProcGen
{
	public class Energy : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.Energy; }

		public Appraisal Evaluate ( State currentState )
		{

			switch ( currentState.AttemptingAction )
			{
				case ActionID.Eat:
				{
					break;
					//return Eat();
				}

				case ActionID.Leisure:
				{
					return Leisure( currentState );
				}

			
			}

			return new Appraisal();
		}

		private Appraisal Leisure( State currentState )
		{
			// Statistically, people with the following traits are more likely to be active, while Neurotic people are less likely
			// Link to paper - https://www.ncbi.nlm.nih.gov/pmc/articles/PMC5650243/

			List<float> traits = new List<float>()
			{
				currentState.Personality.Openness,
				currentState.Personality.Exatraversion,
				currentState.Personality.Agreeableness,
				currentState.Personality.Conscientiousness
			};

			float divisor = currentState.Personality.Neuroticism;
			if ( divisor < float.Epsilon )
				divisor = float.Epsilon;

			return new Appraisal()
			{
				BaseUtility = traits.Max() * currentState.Utilities.Energy / divisor,
				Multiplier = currentState.ActionHistory.First.Value.ID == ActionID.Sleep ? 0f : 1f
			};
		}
	}
}