using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public GameObject[] enemy;
	public float incrementValue = 0.25f;
	
	// Class Variables
	private float speedValue = 2.5f;
	private float speedLimit = 15f;
	private int killCounter = 0;
	private int killLimit = 25;

	void Start () 
	{
		Initialize ();
		InvokeRepeating ("Spawn", 0.01f, 2.5f);
		InvokeRepeating ("IncrementSpeed", 0.01f, 10.0f); // Could just make this a part of the Spawn method.
	}
	
	void Initialize ()
	{
		killCounter = 0;
	}
	
	void Spawn ()
	{	
		foreach (Transform child in gameObject.transform)
		{
			Instantiate (ChooseEnemy (), child.transform.position, child.transform.rotation);	
		}
	}
	
	void IncrementSpeed ()
	{
		if (speedValue >= speedLimit) CancelInvoke ("IncrementSpeed");
		speedValue += incrementValue;
	}
	
	void SetSpeed (GameObject enemy)
	{
		enemy.GetComponent<Planes> ().speed = speedValue;
	}
	
	GameObject ChooseEnemy ()
	{
		GameObject chosenEnemy;
		
		// Randomized range will scale towards the later game to spawn more difficult planes.
		int seconds = FindObjectOfType<Timer> ().getSeconds ();
		int number = Random.Range (seconds / 5, seconds);
		
		if 		(number >= 0 && number <= 10) 	chosenEnemy = enemy[1];
		else if (number > 10 && number <= 40)	chosenEnemy = enemy[2];
		else if (number > 40 && number <= 70)	chosenEnemy = enemy[3];
		else if (number > 70 && number <= 100)	chosenEnemy = enemy[4];
		else if (number > 100 && number <= 130)	chosenEnemy = enemy[5];
		else if (number > 130 && number <= 160) chosenEnemy = enemy[6];
		else if (number > 160 && number <= 190) chosenEnemy = enemy[7];
		else if (number > 190 && number <= 220) chosenEnemy = enemy[8];
		else if (number > 250 && number <= 280) chosenEnemy = enemy[9];
		else if (number > 280 && number <= 310) 
		{
			// This is pretty ugly.
			number = Random.Range (0, 3);
			switch (number)
			{
				case 0:
					chosenEnemy = enemy[10];
					break;
				case 1:
					chosenEnemy = enemy[11];
					break;
				case 2:
					chosenEnemy = enemy[12];
					break;
				default:
					chosenEnemy = enemy[1];
					break;
			}
		}
		else 									chosenEnemy = enemy[1];
	
		// If the weapon drop enemy does spawn, then reset the kill counter so we don't try and generate it anymore.
		if (killCounter >= killLimit)
		{
			number = Random.Range (0, 4);
			if (number == 1 || number == 3) 
			{ 
				chosenEnemy = enemy[0]; 
				killCounter = 0; 
			}
		}
	
		SetSpeed (chosenEnemy);
		return chosenEnemy;
	}
	
	public void addKill ()
	{
		++killCounter;
	}
}
