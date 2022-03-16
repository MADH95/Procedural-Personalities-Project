
using UnityEngine;

namespace ProcGen
{
	[CreateAssetMenu( fileName = "RandomNoise", menuName = "ScriptableObject/Considerations/RandomNoise" )]
	public class RandomNoise : Consideration
	{
		public override ConsiderationID ID { get => ConsiderationID.RandomNoise; }

		public override Appraisal Evaluate ( State currentState )
		{
			return new Appraisal()
			{
				BaseUtility = Random.Range( 0f, 1f ),
				Multiplier = 1f
			};
		}
	}
}