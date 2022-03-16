
using UnityEngine;

namespace ProcGen
{
	public struct Utilities
	{
		public float Hunger { get; set; }

		public float Money { get; set; }

		public float Energy { get; set; }

		public string OutputLine { get; set; }

		public void Clamp()
		{
			Hunger = Mathf.Clamp01( Hunger );
			Money = Mathf.Clamp01( Money );
			Energy = Mathf.Clamp01( Energy );
		}

		public void Generate( int seed )
		{
			var prevState = Random.state;
			Random.InitState( seed * 2 );

			Hunger = Random.Range( 0f, 1f );
			Money = Random.Range( 0f, 1f );
			Energy = Random.Range( 0f, 1f );

			Random.state = prevState;
		}
	}
}