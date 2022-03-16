using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ProcGen
{
	public class Actor : MonoBehaviour
	{
		public new string name;

		public List<Task> actions;

		public Utilities utilities;

		public Personality personality;

		[HideInInspector]
		public List<Task> actionHistory = new List<Task>( MAX_ACTIONS );

		[HideInInspector]
		public Task currentAction;

		private const int MAX_ACTIONS = 4;

		private State CurrentState
		{
			get
			{
				return new State()
				{
					Personality = personality,
					Utilities = utilities,
					ActionHistory = actionHistory
				};
			}
		}

		private void Start ()
		{
			int seed = ++CharacterManager.Seed;
			personality = Personality.Generate( seed );
			utilities.Generate( seed );
		}

		private void Update ()
		{
			State state = CurrentState;

			if ( currentAction != null )
			{
				currentAction.Perform( ref utilities );

				utilities.Clamp();

				if ( !currentAction.CanChange )
					return;
			}

			Dictionary<Task, float> utilVals = new Dictionary<Task, float>( actions.Count );


			for ( int i = 0; i < actions.Count; ++i )
			{
				state.AttemptingAction = actions[ i ].ID;

				utilVals.Add( actions[ i ], actions[ i ].CalculateUtility( state ) );

				//Debug.Log( $"{ name }: { actions[ i ].ID } - { utilVals[ actions[ i ] ] }" );
			}

			currentAction = utilVals.OrderByDescending( entry => entry.Value ).First().Key;

			actionHistory.Insert( 0, currentAction );

			while ( actionHistory.Count > MAX_ACTIONS )
			{
				actionHistory.RemoveAt( actionHistory.Count - 1 );
			}

			currentAction.Initialise( ref utilities );
		}
	}
}