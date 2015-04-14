using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour 
{
	public Text scoreText;
	private int score;
	private int highScore;
	private string highScoreKey = "highScore";

	// Getters (this is probably a very poor design choice! come back to this and re-evaluate it.)
	public int getScore ()		{ return score; }
	public int getHighScore ()	{ return highScore; }

	// Use this for initialization
	void Start () 
	{
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (highScore < score) highScore = score;
		
		scoreText.text = score.ToString ();
	}
	
	private void Initialize ()
	{
		score = 0;
		highScore = PlayerPrefs.GetInt (highScoreKey);
	}
	
	public void AddPoints (int points)
	{
		score += points;
		scoreText.text = score.ToString ();
	}
	
	public void Save ()
	{
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();
		Destroy (gameObject);
	}
}
