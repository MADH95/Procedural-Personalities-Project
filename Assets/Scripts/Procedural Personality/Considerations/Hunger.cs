
namespace ProcGen
{
	public class Hunger : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.Hunger; }

		public Appraisal Evaluate ( State currentState )
		{
			if ( currentState.AttemptingAction == ActionID.Sleep ||
				 currentState.AttemptingAction == ActionID.Relax )
			{
				return new Appraisal()
				{
					BaseUtility = 1f - currentState.Utilities.Hunger,
					Multiplier = 1f
				};
			}

			return new Appraisal()
			{
				BaseUtility = currentState.Utilities.Hunger,
				Multiplier = 1f
			};
		}
	}
}