
namespace ProcGen
{
	public class Lonliness : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.Lonliness; }

		public Appraisal Evaluate ( State currentState )
		{
			return new Appraisal()
			{
				BaseUtility = currentState.Utilities.Lonliness,
				Multiplier = 1f
			};
		}
	}
}