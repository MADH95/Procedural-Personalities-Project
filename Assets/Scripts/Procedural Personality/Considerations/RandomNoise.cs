
using UnityEngine;

namespace ProcGen
{
	public class RandomNoise : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.RandomNoise; }

		public Appraisal Evaluate ( State currentState )
		{
			return new Appraisal()
			{
				BaseUtility = Random.Range( 0f, 1f ),
				Multiplier = 1f
			};
		}
	}
}