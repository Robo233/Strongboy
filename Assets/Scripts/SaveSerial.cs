using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSerial : MonoBehaviour
{
	public int intToSave;
	public string stringToSave;

	public void LoadGame()
	{
		if (PlayerPrefs.HasKey("SavedInteger"))
		{
			intToSave = PlayerPrefs.GetInt("SavedInteger");
			stringToSave = PlayerPrefs.GetString("SavedString");
			Debug.Log("Game data loaded!" + stringToSave);
		}
		else
			Debug.LogError("There is no save data!");
	}
}