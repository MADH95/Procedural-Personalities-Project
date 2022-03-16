
using UnityEngine;
namespace ProcGen
{
	[CreateAssetMenu( fileName = "Hunger", menuName = "ScriptableObject/Considerations/Hunger" )]
	public class Hunger : Consideration
	{
		public override ConsiderationID ID { get => ConsiderationID.Hunger; }

		public bool Inverted;

		public override Appraisal Evaluate ( State currentState )
		{
			float power = 3f;

			float value = currentState.Utilities.Hunger;

			if ( Inverted )
				value = 1f - value;

			return new Appraisal()
			{
				BaseUtility = 0.2f,
				Multiplier = 1f + Mathf.Pow( value, power ),
			};
		}
	}
}