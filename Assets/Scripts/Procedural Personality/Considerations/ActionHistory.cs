using System.Linq;

namespace ProcGen
{
	public class ActionHistory : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.ActionHistory; }

		public Appraisal Evaluate ( State currentState )
		{
			return new Appraisal()
			{
				BaseUtility = currentState.ActionHistory.ToList().FindIndex( elem => elem.ID == currentState.AttemptingAction ),
				Multiplier	= 1f
			};
		}
	}
}