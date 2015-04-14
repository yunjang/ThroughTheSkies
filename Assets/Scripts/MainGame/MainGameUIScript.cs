using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGameUIScript : MonoBehaviour 
{
	public GameObject[] shipList;
	public GameObject scoreFrame;
	public GameObject pauseMenu;
	public Text currentScoreUI;
	public Text currentTimeUI;
	public Text bestScoreUI;
	public Text bestTimeUI;

	private bool gamePaused;

	// A separate file for global constants is going to be a smarter idea!
	private string shipSelectionKey = "ShipSelectKey";

	// Use this for initialization
	void Start () 
	{
		InstantiateShip ();
		gamePaused = false;
		scoreFrame.SetActive (false);	
		pauseMenu.SetActive (false);
	}
	
	void InstantiateShip ()
	{
		string selectedShip = PlayerPrefs.GetString (shipSelectionKey);
		
		if (selectedShip == "TYPE ZERO")	Instantiate (shipList[0]);
		if (selectedShip == "DOGE")			Instantiate (shipList[7]);
	}
	
	public void ShowResults ()
	{
		// Get the result objects and show the information.
		Score score = FindObjectOfType<Score> ();
		Timer timer = FindObjectOfType<Timer> ();
		score.Save ();
		timer.Save ();
		
		// Update the display with the score.
		currentScoreUI.text = score.getScore ().ToString ();
		bestScoreUI.text = score.getHighScore ().ToString ();		
		currentTimeUI.text = string.Format ("{0:0}:{1:00}", timer.getSeconds () / 60, timer.getSeconds () % 60);
		bestTimeUI.text = string.Format ("{0:0}:{1:00}", timer.getBestSeconds () / 60, timer.getBestSeconds () % 60);
		
		// Once we set the results and everything, display the results.
		scoreFrame.SetActive (true);
	}
	
	public void PauseGame ()
	{
		Timer timer = FindObjectOfType<Timer> ();
	
		// Set the time scale to zero so everything comes to a halt.
		if (!gamePaused)
		{
			Time.timeScale = 0;
			timer.enabled = false;
			gamePaused = true;
			pauseMenu.SetActive (true);
		}
		else
		{ 				
			Time.timeScale = 1;
			timer.enabled = true;
			gamePaused = false;
			pauseMenu.SetActive (false);
		}
	}
	
	public void RestartGame ()
	{
		Application.LoadLevel ("MainGame");
	}
	
	public void GoToMainMenu ()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("MainMenu");
	}
}
