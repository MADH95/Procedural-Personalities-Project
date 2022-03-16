
using System;
using UnityEngine;
namespace ProcGen
{
	[CreateAssetMenu( fileName = "Personal", menuName = "ScriptableObject/Considerations/Personal" )]
	public class Personal : Consideration
	{
		public override ConsiderationID ID { get => ConsiderationID.Personal; }

		public override Appraisal Evaluate ( State currentState ) => currentState.AttemptingAction switch
		{
			ActionID.Sleep => Sleep( currentState ),

			ActionID.Eat => Eat( currentState ),
			
			ActionID.Work => Work( currentState ),
			
			_ => new Appraisal()
			{
				BaseUtility = 0f,
				Multiplier = 1f,
			},
		};

		private Appraisal Sleep( State currentState )
		{
			//The largest predictors of poor sleep are low conscientiousness and high neuroticism
			// Link to paper - https://www.ncbi.nlm.nih.gov/pmc/articles/PMC3961248/

			float value = currentState.Personality.Neuroticism + ( 1 - currentState.Personality.Conscientiousness );

			return new Appraisal()
			{
				BaseUtility = value / 2f,
				Multiplier = 1f
			};
		}

		private Appraisal Eat( State currentState )
		{
			//Poor interpretation, but low agreeableness is associated with skipping meals, while high extraversion and openness are associated with food interest.
			// Link to Paper - https://bmcpsychology.biomedcentral.com/articles/10.1186/s40359-019-0286-z

			float value = ( 1 - currentState.Personality.Agreeableness ) + currentState.Personality.Exatraversion + currentState.Personality.Openness;

			return new Appraisal()
			{
				BaseUtility = value / 3,
				Multiplier = 1f
			};
		}

		private Appraisal Work( State currentState )
		{
			// Relationships between the big 5 and work involement correlate possitively with extroversion x openness and negatively with agreeableness. Measured on clerical, administrative, and managerial positions, but may work as a simplistic definition.
			// Link to paper - https://www.researchgate.net/publication/235264724_The_Big_Five_of_personality_and_work_involvement

			float value = ( float ) Math.Sqrt( currentState.Personality.Exatraversion * currentState.Personality.Openness );

			value += 1 - currentState.Personality.Agreeableness;

			return new Appraisal()
			{
				BaseUtility = value / 2,
				Multiplier = 1f
			};
		}
	}
}
