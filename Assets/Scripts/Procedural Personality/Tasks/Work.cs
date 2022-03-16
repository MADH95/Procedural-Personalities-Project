using System.Collections.Generic;

using UnityEngine;

namespace ProcGen
{
	[CreateAssetMenu( fileName = "Work", menuName = "ScriptableObject/Actions/Work" )]
	public class Work : Task
	{
		public override ActionID ID { get => ActionID.Work; }

		List<string> lines = new List<string>()
		{
			"attending to patients.",
			"working on a project.",
			"giving someone a great haircut.",
			"building a new cabinet.",
			"teaching the youth of the world."
		};

		private const float step = 0.001f;
		private const float timeToWork = 8f * 3600f * CharacterManager.InGameSecond;
		private float workAccum = 0f, timeAccum = 0f;

		public override void Initialise ( ref Utilities utilities )
		{
			CanChange = false;
			workAccum = Random.Range( 0f, timeToWork * 0.5f );

			utilities.OutputLine = lines[ Random.Range( 0, lines.Count ) ];
		}

		public override bool Perform ( ref Utilities utilities )
		{
			if ( utilities.Money == 1f )
				CanChange = true;

			workAccum += Time.deltaTime;
			timeAccum += Time.deltaTime;

			if ( timeAccum > CharacterManager.InGameSecond )
			{
				timeAccum = 0f;
				utilities.Money += step;
				utilities.Hunger += step;
				utilities.Energy -= step;

				return true;
			}

			if ( workAccum > timeToWork )
			{
				CanChange = true;
			}

			return false;
		}

	}
}
