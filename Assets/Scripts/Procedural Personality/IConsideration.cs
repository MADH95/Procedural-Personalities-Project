
namespace ProcGen
{
	public interface IConsideration
	{
		//public DataNode Data { get; set; }

		public Appraisal Evaluate ( ref State currentState );
	}
}