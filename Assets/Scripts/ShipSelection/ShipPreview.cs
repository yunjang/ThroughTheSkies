using UnityEngine;
using System.Collections;

public class ShipPreview : MonoBehaviour 
{
	// Planes component
	Planes plane;

	// Calling a coroutine inside the Start method.
	// This ensures that the game progresses normally without the bullet taking the entire process.
	// Documentation: http://docs.unity3d.com/Manual/Coroutines.html
	IEnumerator Start ()
	{
		plane = GetComponent<Planes> ();
		Initialize ();
	
		while (true)
		{
			// Creates bullet based on the plane's position with this method.
			plane.Shot (transform);
			yield return new WaitForSeconds (plane.shotDelay);
		}
	}
	
	void Initialize ()
	{
		plane.bullet.GetComponent<BulletScript> ().dmg = 1;
	}
}
