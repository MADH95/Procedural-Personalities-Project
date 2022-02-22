using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ProcGen
{
	public class Actor : MonoBehaviour
	{
		[SerializeField] //TODO: custom Editor for Utilities
		private Utilities utilities;

		[SerializeField] //TODO: custom Editor for Personality
		private Personality personality;

		[SerializeField]
		private List<Task> actions;

		private Task currentAction = new Relax();
		
		private LinkedList<Task> actionHistory;
		private const int MAX_ACTIONS = 5;

		private State CurrentState
		{
			get
			{
				return new State()
				{
					TimeOfDay = 12.0f,              //TODO: Implement rudamentory day cycle
					Personality = personality,
					Utilities = utilities,
					ActionHistory = actionHistory
				};
			}
		}

		private void Start ()
		{
			// incase custom editor is too difficult
			//personality = Personality.Generate();
		}

		private void Update ()
		{
			currentAction.Perform();

			if ( !currentAction.CanChange )
				return;

			Dictionary<Task, float> utilVals = new Dictionary<Task, float>( actions.Count );

			State state = CurrentState;

			for ( int i = 0; i < actions.Count; ++i )
			{
				state.AttemptingAction = actions[ i ].ID;

				utilVals.Add( actions[ i ], actions[ i ].CalculateUtility( state ) );
			}

			currentAction = utilVals.OrderByDescending( entry => entry.Value ).First().Key;

			actionHistory.AddFirst( currentAction );

			while ( actionHistory.Count > MAX_ACTIONS )
			{
				actionHistory.RemoveLast();
			}
		}
	}
}