using System.Linq;

namespace ProcGen
{
	public class ActionHistory : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.ActionHistory; }

		public Appraisal Evaluate ( State currentState )
		{
			float value = currentState.ActionHistory.ToList().FindIndex( elem => elem.ID == currentState.AttemptingAction );

			value = value * 1f / currentState.ActionHistory.Count;

			return new Appraisal()
			{
				BaseUtility = value,
				Multiplier	= 1f
			};
		}
	}
}