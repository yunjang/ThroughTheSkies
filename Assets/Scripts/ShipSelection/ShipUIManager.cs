using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ShipUIManager : MonoBehaviour 
{
	List<GameObject> shipList;
	public GameObject[] ships;
	public Text shipName;
	
	private string shipSelectionKey = "ShipSelectKey";

	void Start ()
	{
		shipList = new List<GameObject> ();
		pressTypeZero ();
	}
	
	void ClearList ()
	{
		foreach (GameObject obj in shipList) { Destroy (obj); }
		shipList.Clear ();
	}

	public void pressTypeZero ()
	{
		ClearList ();
		shipList.Add((GameObject) Instantiate (ships[0]));
		shipName.text = "TYPE ZERO";
	}
	
	public void pressTypeOne ()
	{
		ClearList ();
		shipList.Add ((GameObject) Instantiate (ships[1]));
		shipName.text = "TYPE ONE";
	}
	
	public void pressTypeTwo ()
	{
		ClearList ();
		shipList.Add ((GameObject) Instantiate (ships[2]));
		shipName.text = "TYPE TWO";
	}
	
	public void pressTypeThree ()
	{
		ClearList ();
		shipList.Add ((GameObject) Instantiate (ships[3]));
		shipName.text = "TYPE THREE";
	}
	
	public void pressBlazingEagle ()
	{
		ClearList ();
		shipList.Add ((GameObject) Instantiate (ships[4]));
		shipName.text = "BLAZING EAGLE";
	}
	
	public void pressDefinitelyNotGalaga ()
	{
		ClearList ();
		shipList.Add ((GameObject) Instantiate (ships[5]));
		shipName.text = "DEFINITELY NOT GALAGA";
	}
	
	public void pressSpaceAnimals ()
	{
		ClearList ();
		shipList.Add ((GameObject) Instantiate (ships[6]));
		shipName.text = "SPACE ANIMAL";
	}
	
	public void pressDoge ()
	{
		ClearList ();
		shipList.Add ((GameObject) Instantiate (ships[7]));
		shipName.text = "DOGE";
	}

	public void ConfirmSelection ()
	{
		PlayerPrefs.SetString (shipSelectionKey, shipName.text);
		PlayerPrefs.Save ();
		Application.LoadLevel ("MainGame");
	}
}
