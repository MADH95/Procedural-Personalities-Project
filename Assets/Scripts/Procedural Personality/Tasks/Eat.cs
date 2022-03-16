using System.Collections.Generic;
using UnityEngine;

namespace ProcGen
{
	[CreateAssetMenu( fileName = "Eat", menuName = "ScriptableObject/Actions/Eat" )]
	public class Eat : Task
	{
		public override ActionID ID { get => ActionID.Eat; }

		List<string> lines = new List<string>()
		{
			"having a nice meal.",
			"snacking on some treats.",
			"indulging when they shouldn't.",
			"eating 1 of their 5 a day.",
			"keeping the doctor away."
		};

		private const float step = 0.001f;
		private const float timeToEat = 30f * 60f * CharacterManager.InGameSecond;
		private float eatAccum = 0f, timeAccum = 0f;

		public override void Initialise ( ref Utilities utilities )
		{
			CanChange = false;
			eatAccum = Random.Range( 0f, timeToEat * 0.25f );

			utilities.OutputLine = lines[ Random.Range( 0, lines.Count ) ];

			utilities.Money -= Random.Range( 0f, utilities.Money * 0.9f );
		}

		public override bool Perform ( ref Utilities utilities )
		{
			if ( utilities.Hunger == 0f )
				CanChange = true;

			eatAccum += Time.deltaTime;
			timeAccum += Time.deltaTime;

			if ( timeAccum > CharacterManager.InGameSecond )
			{
				timeAccum = 0f;
				utilities.Hunger -= step;

				return true;
			}

			if ( eatAccum >= timeToEat )
			{
				CanChange = true;
			}

			return false;
		}
	}
}