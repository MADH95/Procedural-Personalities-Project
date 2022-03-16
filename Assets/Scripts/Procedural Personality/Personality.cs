using UnityEngine;

namespace ProcGen
{
	public class Personality
	{
		public float Openness { get; private set; }

		public float Conscientiousness { get; private set; }

		public float Exatraversion { get; private set; }

		public float Agreeableness { get; private set; }

		public float Neuroticism { get; private set; }

		static public Personality Generate ()
		{
			return new Personality()
			{
				Openness			= Random.Range( 0f, 1f ),
				Conscientiousness	= Random.Range( 0f, 1f ),
				Exatraversion		= Random.Range( 0f, 1f ),
				Agreeableness		= Random.Range( 0f, 1f ),
				Neuroticism			= Random.Range( 0f, 1f )
			};
		}

		static public Personality Generate ( int seed )
		{
			var prevState = Random.state;

			Random.InitState( seed );

			Personality person = Generate();

			Random.state = prevState;

			return person;
		}
	}
}