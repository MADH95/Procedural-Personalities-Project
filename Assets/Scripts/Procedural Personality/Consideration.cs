
using UnityEngine;

namespace ProcGen
{
	public abstract class Consideration : ScriptableObject
	{
		//public DataNode Data { get; set; }

		public abstract ConsiderationID ID { get; }

		public abstract Appraisal Evaluate ( State currentState );
	}
}