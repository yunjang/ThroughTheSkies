using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour 
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

	// Update is called once per frame
	void Update () 
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
		{
			// This adds acceleration to the positional translation based on input.
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			rigidbody2D.transform.Translate (touchDeltaPosition.x * plane.speed, touchDeltaPosition.y * plane.speed, 0);
		}	
		
		// Bounds check. When the assets change, the values will need some tweaking.
		if (rigidbody2D.transform.position.x <= -2.5f) { rigidbody2D.transform.position = new Vector2 (-2.5f, rigidbody2D.transform.position.y); }
		else if (rigidbody2D.transform.position.x >= 2.5f) { rigidbody2D.transform.position = new Vector2 (2.5f, rigidbody2D.transform.position.y); }
		if (rigidbody2D.transform.position.y <= -4.5f) { rigidbody2D.transform.position = new Vector2 (rigidbody2D.transform.position.x, -4.5f); }
		else if (rigidbody2D.transform.position.y >= -0.5f) { rigidbody2D.transform.position = new Vector2 (rigidbody2D.transform.position.x, -0.5f); }
	}
	
	void OnTriggerEnter2D (Collider2D c)
	{
		/* You need to use layering in order to fine tune the colliders. */
		
		// Gets the layer name.
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		if (layerName == "Bullet (Enemy)" || layerName == "Upgrade")
		{
			// Delete the object that collides with the plane.
			Destroy (c.gameObject);
			if (layerName == "Upgrade") { upgradeWeapon (c.gameObject); }
		}
		
		// Make some sort of explosion method that gets triggered.
		
		if (layerName == "Bullet (Enemy)" || layerName == "Enemy")
		{
			// Destroy this game object.
			Destroy (gameObject);
			
			// Once the ship is hit, I should destroy all the game objects on screen and allow Play Again.
			foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
			{
				string name = LayerMask.LayerToName (o.layer);
				if (name == "Bullet (Enemy)" || name == "Bullet (Player)" ||
					name == "Player" || name == "Enemy" || o.name == "Spawner1")
				{
					Destroy (o);
				}
			}
			
			// Find the UIManager object and then show the button.
			FindObjectOfType<MainGameUIScript> ().ShowResults ();
		}
	}
	
	void upgradeWeapon (GameObject c)
	{
		if (c.gameObject.tag == "DamageUp") 
			++(plane.bullet.GetComponent<BulletScript> ().dmg);
		else if (c.gameObject.tag == "FireRateUp")
			plane.shotDelay -= 0.05f;
	}
}
