using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour 
{
	public int speed = 10;
	public int lifeTime = 5;
	public int dmg = 1;

	// Use this for initialization
	void Start () 
	{
		rigidbody2D.velocity = transform.up.normalized * speed;
		Destroy (gameObject, lifeTime);
	}
}
