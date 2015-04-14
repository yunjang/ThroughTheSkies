using UnityEngine;
using System.Collections;

public class CleanUpAreaScript : MonoBehaviour 
{
	void OnTriggerEnter2D (Collider2D c)
	{
		Destroy (c.gameObject);
	}
}
