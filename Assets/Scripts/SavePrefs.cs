using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePrefs : MonoBehaviour
{

	public int intToSave;
    string stringToSave = "A Nagy Elod";
	GameOver gameOver;

	void Start()
    {
		GameObject EnemyCollider = GameObject.Find("EnemyCollider");
		gameOver = EnemyCollider.GetComponent<GameOver>();
	}

	public void SaveGame()
	{
		intToSave = gameOver.BestScore;
		PlayerPrefs.SetInt("SavedInteger", intToSave);
		PlayerPrefs.SetString("SavedString", stringToSave);
		PlayerPrefs.Save();
		Debug.Log("Game data saved! ");
		Debug.Log(intToSave);
	}
}
