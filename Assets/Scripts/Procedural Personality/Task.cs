
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ProcGen
{
	public abstract class Task : ScriptableObject
	{
		public abstract ActionID ID { get; }

		public List<Consideration> Considerations;

		public bool CanChange { get; set; } = true;

		public virtual float CalculateUtility ( State currentState )
		{
			List<Appraisal> appraisals = new List<Appraisal>( Considerations.Count );

			foreach ( var consideration in Considerations )
			{
				appraisals.Add( consideration.Evaluate( currentState ) );
			}

			float utility = appraisals.Aggregate( 0f, ( accum, elem ) => accum + elem.BaseUtility );

			return appraisals.Aggregate( utility, ( accum, elem ) => accum * elem.Multiplier );
		}

		public abstract void Initialise ( ref Utilities utilities );

		public abstract bool Perform( ref Utilities utilities );
	}
}