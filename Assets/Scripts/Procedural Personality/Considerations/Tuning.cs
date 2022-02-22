
namespace ProcGen
{
	public class Tuning : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.Tuning; }

		public Appraisal Evaluate ( State currentState )
		{
			return new Appraisal()
			{
				BaseUtility = 1f,
				Multiplier = 1f
			};
		}
	}
}