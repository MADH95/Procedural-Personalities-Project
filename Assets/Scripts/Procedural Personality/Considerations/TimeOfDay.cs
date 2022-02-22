
namespace ProcGen
{
	public class TimeOfDay : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.TimeOfDay; }

		public Appraisal Evaluate ( State currentState )
		{
			return new Appraisal()
			{
				BaseUtility = currentState.TimeOfDay,
				Multiplier = 1f
			};
		}
	}
}