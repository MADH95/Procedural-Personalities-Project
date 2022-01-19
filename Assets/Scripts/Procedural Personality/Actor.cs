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
		private List<ITask> actions;

		private void Start ()
		{

		}

		private void Update ()
		{

		}
	}
}