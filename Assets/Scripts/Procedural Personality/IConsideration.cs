
namespace ProcGen
{
	public interface IConsideration
	{
		//public DataNode Data { get; set; }

		public ConsiderationID ID { get; }

		public Appraisal Evaluate ( State currentState );
	}
}