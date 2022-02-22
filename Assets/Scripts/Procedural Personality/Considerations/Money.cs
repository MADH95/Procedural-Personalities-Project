
namespace ProcGen
{
	public class Money : IConsideration
	{
		public ConsiderationID ID { get => ConsiderationID.Money; }

		public Appraisal Evaluate ( State currentState )
		{
			return new Appraisal()
			{
				BaseUtility = 1 - currentState.Utilities.Money,
				Multiplier = 1f
			};
		}
	}
}