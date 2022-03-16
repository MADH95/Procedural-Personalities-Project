
using UnityEngine;
namespace ProcGen
{
	[CreateAssetMenu( fileName = "ActionHistory", menuName = "ScriptableObject/Considerations/ActionHistory" )]
	public class ActionHistory : Consideration
	{
		public override ConsiderationID ID { get => ConsiderationID.ActionHistory; }

		public override Appraisal Evaluate ( State currentState )
		{
			float value = currentState.ActionHistory.FindIndex( elem => elem.ID == currentState.AttemptingAction );

			if ( value < 0 )
				value = currentState.ActionHistory.Count;

			return new Appraisal()
			{
				BaseUtility = 0f,
				Multiplier	= value / currentState.ActionHistory.Count,
			};
		}
	}
}