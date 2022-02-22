
using System.Linq;
using System.Collections.Generic;

namespace ProcGen
{
	public class Personal : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.Personal; }

		public Appraisal Evaluate ( State currentState )
		{

			return Leisure( currentState );
		}

		private Appraisal Leisure ( State currentState )
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
				BaseUtility = traits.Max() / divisor,
				Multiplier = 1f
			};
		}
	}

	
}
