
using UnityEngine;
namespace ProcGen
{
	[CreateAssetMenu( fileName = "Money", menuName = "ScriptableObject/Considerations/Money" )]
	public class Money : Consideration
	{
		public override ConsiderationID ID { get => ConsiderationID.Money; }

		public bool Inverted;

		public override Appraisal Evaluate ( State currentState )
		{
			float value = currentState.Utilities.Money;

			if ( Inverted )
				value = 1f - value;

			return new Appraisal()
			{
				BaseUtility = 0f,
				Multiplier = 1f + value,
			};
		}
	}
}