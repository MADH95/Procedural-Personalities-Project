
namespace ProcGen
{
	public class Money : IConsideration
	{
		public Appraisal Evaluate ( ref State currentState )
		{
			return new Appraisal();
		}
	}
}