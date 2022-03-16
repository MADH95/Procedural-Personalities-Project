
using UnityEngine;
namespace ProcGen
{
	[CreateAssetMenu( fileName = "Energy", menuName = "ScriptableObject/Considerations/Energy" )]
	public class Energy : Consideration
	{
		public override ConsiderationID ID { get => ConsiderationID.Energy; }

		public bool Inverted;

		public override Appraisal Evaluate ( State currentState )
		{
			float mult = 15f, mid = 0.5f, e = Mathf.Epsilon;

			float value = currentState.Utilities.Energy;

			if ( Inverted )
				value = 1f - value;

			return new Appraisal()
			{
				BaseUtility = 0.3f,
				Multiplier = 1f + ( 1 / ( 1 + Mathf.Pow( e, mult * ( currentState.Utilities.Energy - mid ) ) ) ),
			};
		}
	}
}