using UnityEngine;

namespace ProcGen
{
	public class Personality
	{
		public float Openness { get; set; }

		public float Conscientiousness { get; set; }

		public float Exatraversion { get; set; }

		public float Agreeableness { get; set; }

		public float Neuroticism { get; set; }

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
			Random.InitState( seed );

			return Generate();
		}
	}
}