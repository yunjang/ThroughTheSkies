using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/* Redesign Score/Timer scripts -- might be able to merge them to have less mess!*/
public class Timer : MonoBehaviour 
{
	public Text timerText;
	
	private int time;
	private int seconds;
	private int bestSeconds;
	private string bestSecondsKey = "bestSecondsKey";
	
	// Getters
	public int getSeconds () { return seconds; }
	public int getBestSeconds () { return bestSeconds; }

	// Use this for initialization
	void Start () 
	{
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (bestSeconds < seconds) bestSeconds = seconds;
		++time;
		
		seconds = Mathf.FloorToInt (time / 60); // Divided by 60 frames.
		string formatTime = string.Format ("{0:0}:{1:00}", Mathf.FloorToInt (seconds / 60), seconds % 60);		
		timerText.text = formatTime;
	}
	
	public void Initialize ()
	{
		time = 0;
		seconds = 0;
		bestSeconds = PlayerPrefs.GetInt (bestSecondsKey);
	}
	
	public void Save ()
	{
		PlayerPrefs.SetInt (bestSecondsKey, bestSeconds);
		PlayerPrefs.Save ();
		Destroy (gameObject);
	}
}
