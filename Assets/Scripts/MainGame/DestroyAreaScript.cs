using UnityEngine;
using System.Collections;

public class DestroyAreaScript : MonoBehaviour 
{
	void OnTriggerExit2D (Collider2D c)
	{
		Destroy (c.gameObject);
	}
}
