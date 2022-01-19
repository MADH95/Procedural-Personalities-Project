
namespace ProcGen
{
	public class Hunger : IConsideration
	{
		public Appraisal Evaluate ( ref State currentState )
		{
			return new Appraisal();
		}
	}
}