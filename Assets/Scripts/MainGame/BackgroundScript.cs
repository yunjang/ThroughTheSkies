using UnityEngine;
using System.Collections;

public class BackgroundScript : MonoBehaviour 
{
	public float speed = 0.1f;
			
	// Update is called once per frame
	void Update () 
	{
		// This makes the Y value go from 0 to 1 over time. Once Y is 1, it'll go back to 0.
		float y = Mathf.Repeat (Time.time * speed, 1);
		
		Vector2 offset = new Vector2 (0, y);
		
		renderer.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
