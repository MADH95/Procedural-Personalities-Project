
namespace ProcGen
{
	public class Weather : IConsideration
	{
		public Appraisal Evaluate ( ref State currentState )
		{
			return new Appraisal();
		}
	}
}