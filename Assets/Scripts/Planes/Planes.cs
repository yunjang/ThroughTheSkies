using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Planes : MonoBehaviour 
{
	public float speed;
	public float shotDelay;
	public GameObject bullet;
	public bool canShoot;
	public GameObject explosion;
	public GameObject[] upgrade;
	
	public void Shot (Transform origin)
	{
		Instantiate (bullet, origin.position, origin.rotation);
	}

	public void Move (Vector2 direction)
	{
		rigidbody2D.velocity = direction * speed;
	}
	
	public void Explode ()
	{
		Instantiate (explosion, transform.position, transform.rotation);
	}

	public void dropUpgrade ()
	{
		GameObject upgradeDrop;
	
		// Since we only have two upgrades, I'll be slightly lazy here.
		int number = Random.Range (0, 2);
		switch (number)
		{
			case 0:
				upgradeDrop = upgrade[0];
				break;
			case 1:
				upgradeDrop = upgrade[1];
				break;
			default:
				upgradeDrop = upgrade[0];
				break;
		}
		
		Instantiate (upgradeDrop, transform.position, transform.rotation);
	}
}
