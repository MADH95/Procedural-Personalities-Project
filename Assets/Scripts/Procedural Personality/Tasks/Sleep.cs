using System.Collections.Generic;

using UnityEngine;

namespace ProcGen
{
	[CreateAssetMenu( fileName = "Sleep", menuName = "ScriptableObject/Actions/Sleep" )]
	public class Sleep : Task
	{
		public override ActionID ID { get => ActionID.Sleep; }

		List<string> lines = new List<string>()
		{
			"snoring too loud.",
			"counting sheep.",
			"having a bad dream.",
			"dreaming of somewhere magical.",
			"struggling to find rest."
		};

		private const float step = 0.001f;
		private const float timeToSleep = 9f * 3600f * CharacterManager.InGameSecond;
		private float sleepAccum = 0f, timeAccum = 0f;

		public override void Initialise ( ref Utilities utilities )
		{
			CanChange = false;
			sleepAccum = Random.Range( 0f, timeToSleep * 0.22f );

			utilities.OutputLine = lines[ Random.Range( 0, lines.Count ) ];
		}

		public override bool Perform ( ref Utilities utilities )
		{
			if ( utilities.Hunger == 1f || utilities.Energy == 1f )
				CanChange = true;

			sleepAccum += Time.deltaTime;
			timeAccum += Time.deltaTime;

			if ( timeAccum > CharacterManager.InGameSecond )
			{
				timeAccum = 0f;
				utilities.Hunger += step;
				utilities.Energy += step;

				return true;
			}

			if ( sleepAccum > timeToSleep )
			{
				CanChange = true;
			}

			return false;
		}
	}
}
