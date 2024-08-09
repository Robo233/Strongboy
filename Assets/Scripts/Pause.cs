using System;
using UnityEngine;

// Token: 0x0200000C RID: 12
public class Pause : MonoBehaviour
{
	// Token: 0x06000041 RID: 65 RVA: 0x00003480 File Offset: 0x00001680
	public void PauseTime()
	{
		this.isPlaying = false;
		Time.timeScale = 0f;
		this.PauseButton.SetActive(false);
		this.PauseMenuBackground.SetActive(true);
		this.objectGeneratorPrefab.enabled = false;
		this.currentSpeed = this.speed.SpeedValue;
		this.speed.SpeedValue = 0f;
		this.speed.SpeedIncrease = 0f;
		this.enemyGenerator.enabled = false;
		this.SoundButton.SetActive(true);
		this.animator.enabled = false;
		this.Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		this.Camera.GetComponent<AudioSource>().enabled = false;
		this.Player.GetComponent<AudioSource>().enabled = false;
		for (int i = 0; i < this.Enemies.Length; i++)
		{
			this.Enemies[i].GetComponent<Animator>().enabled = false;
		}
		this.Prefabs = GameObject.FindGameObjectsWithTag("Prefab");
		this.Roads = GameObject.FindGameObjectsWithTag("Road");
		for (int j = 0; j < this.Prefabs.Length; j++)
		{
			this.Prefabs[j].GetComponent<ObjectMovement>().enabled = false;
		}
		for (int k = 0; k < this.Roads.Length; k++)
		{
			this.Roads[k].GetComponent<ObjectMovement>().enabled = false;
		}
	}

	// Token: 0x06000042 RID: 66 RVA: 0x000035DC File Offset: 0x000017DC
	public void ResumeTime()
	{
		this.isPlaying = true;
		Time.timeScale = 1f;
		this.PauseButton.SetActive(true);
		this.PauseMenuBackground.SetActive(false);
		this.PauseMenuBackground.SetActive(false);
		this.speed.SpeedIncrease = 0.0015f;
		this.speed.SpeedValue = this.currentSpeed;
		this.objectGeneratorPrefab.enabled = true;
		this.enemyGenerator.enabled = true;
		this.SoundButton.SetActive(false);
		this.animator.enabled = true;
		this.Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		this.Camera.GetComponent<AudioSource>().enabled = true;
		this.Player.GetComponent<AudioSource>().enabled = true;
		for (int i = 0; i < this.Enemies.Length; i++)
		{
			this.Enemies[i].GetComponent<Animator>().enabled = true;
		}
		for (int j = 0; j < this.Prefabs.Length; j++)
		{
			this.Prefabs[j].GetComponent<ObjectMovement>().enabled = true;
		}
		for (int k = 0; k < this.Roads.Length; k++)
		{
			this.Roads[k].GetComponent<ObjectMovement>().enabled = true;
		}
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00003713 File Offset: 0x00001913
	private void OnApplicationPause(bool pause)
	{
		if (pause && !this.GameOverMenu.activeSelf && this.isPlaying)
		{
			this.PauseTime();
		}
	}

	// Token: 0x0400007B RID: 123
	public GameObject SoundButton;

	// Token: 0x0400007C RID: 124
	public GameObject Player;

	// Token: 0x0400007D RID: 125
	public GameObject SceneLoader;

	// Token: 0x0400007E RID: 126
	public GameObject Camera;

	// Token: 0x0400007F RID: 127
	public GameObject PauseMenuBackground;

	// Token: 0x04000080 RID: 128
	public GameObject PauseButton;

	// Token: 0x04000081 RID: 129
	public GameObject GameOverMenu;

	// Token: 0x04000082 RID: 130
	private GameObject[] Prefabs;

	// Token: 0x04000083 RID: 131
	private GameObject[] Roads;

	// Token: 0x04000084 RID: 132
	private GameObject[] Enemies;

	// Token: 0x04000085 RID: 133
	public EnemyGenerator enemyGenerator;

	// Token: 0x04000086 RID: 134
	public ObjectGeneratorPrefab objectGeneratorPrefab;

	// Token: 0x04000087 RID: 135
	public Speed speed;

	// Token: 0x04000088 RID: 136
	public Animator animator;

	// Token: 0x04000089 RID: 137
	public Menu menu;

	// Token: 0x0400008A RID: 138
	private float currentSpeed;

	// Token: 0x0400008B RID: 139
	public bool isPlaying;
}
