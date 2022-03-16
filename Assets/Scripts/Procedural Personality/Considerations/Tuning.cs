
using UnityEngine;

namespace ProcGen
{
	[CreateAssetMenu( fileName = "Tuning", menuName = "ScriptableObject/Considerations/Tuning" )]
	public class Tuning : Consideration
	{
		public override ConsiderationID ID { get => ConsiderationID.Tuning; }

		[Range(0f, 1f)]
		public float tuningValue;

		public override Appraisal Evaluate ( State currentState )
		{
			return new Appraisal()
			{
				BaseUtility = tuningValue,
				Multiplier = 1f
			};
		}
	}
}