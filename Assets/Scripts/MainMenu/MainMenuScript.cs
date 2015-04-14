using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour 
{
	public void StartGame ()
	{
		Application.LoadLevel ("ShipSelection");
	}
	
	public void QuitGame ()
	{
		Application.Quit ();
	}
}
