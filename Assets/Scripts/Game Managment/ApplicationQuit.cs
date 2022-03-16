
using UnityEngine;

public class ApplicationQuit : MonoBehaviour
{
    public void Quit()
	{
		Debug.Log( "Application Quit!" );
		Application.Quit();
	}
}
