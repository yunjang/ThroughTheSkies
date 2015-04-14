using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour 
{
	public int hp = 1;
	public int points = 100;
	Planes plane;
	
	// Use this for initialization
	IEnumerator Start () 
	{
		plane = GetComponent<Planes> ();
		plane.Move (transform.up * -1);
		
		if (plane.canShoot)
		{
			while (true)
			{
				for (int i = 0; i < transform.childCount; ++i)
				{
					Transform shotPos = transform.GetChild (i);
					plane.Shot (shotPos);
				}
				
				yield return new WaitForSeconds (plane.shotDelay);
			}
		}
	}
	
	void OnTriggerEnter2D (Collider2D c)
	{
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		if (layerName == "Bullet (Player)")
		{
			// Get the PlayerBullet's Transform
			// c.transform.parent doesn't return the parent, so I opted in using the root to get the top of the hierarchy.
			Transform playerBulletTransform = c.transform.root;
			
			// Get Bullet Component.
			BulletScript playerBullet = playerBulletTransform.GetComponent<BulletScript> ();
			
			hp -= playerBullet.dmg;
			Destroy (c.gameObject);
			
			if (hp <= 0)
			{
				FindObjectOfType<Score> ().AddPoints (points);
				FindObjectOfType<Spawner> ().addKill ();
				plane.Explode ();
				
				if (gameObject.tag == "EnemyWeaponDrop") plane.dropUpgrade ();
				Destroy (gameObject);
			}
		}
	}
}
