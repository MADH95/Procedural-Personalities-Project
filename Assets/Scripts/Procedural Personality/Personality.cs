
namespace ProcGen
{
	public class Personality
	{
		public float Openness { get; set; }

		public float Conscientiousness { get; set; }

		public float Exatraversion { get; set; }

		public float Agreeableness { get; set; }

		public float Neuroticism { get; set; }

		public Personality Generate ()
		{
			return new Personality();
		}

		public Personality Generate ( int seed )
		{
			return new Personality();
		}
	}
}