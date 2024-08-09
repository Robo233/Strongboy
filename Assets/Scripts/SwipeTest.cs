using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000010 RID: 16
public class SwipeTest : MonoBehaviour
{
	// Token: 0x0600004F RID: 79 RVA: 0x00003A0A File Offset: 0x00001C0A
	private void Start()
	{
		this.BestScore = PlayerPrefs.GetInt("Score");
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00003A1C File Offset: 0x00001C1C
	private void Update()
	{
		this.CounterText.GetComponent<Text>().text = this.score.ToString();
		if (this.score == 10)
		{
			this.CounterText.GetComponent<Text>().rectTransform.anchoredPosition = new Vector2(-185f, -220f);
		}
		if (this.score == 100)
		{
			this.CounterText.GetComponent<Text>().rectTransform.anchoredPosition = new Vector2(-212.8f, -220f);
			this.CounterText.GetComponent<Text>().fontSize = 225;
		}
		if (this.score > this.BestScore)
		{
			this.BestScore = this.score;
			this.gameOver.BestScore = this.BestScore;
			this.SaveGame();
			this.NewHighscoreText.SetActive(true);
		}
		this.Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>().FindAll((GameObject x) => Vector3.Distance(this.Player.transform.position, x.transform.position) < this.Distance);
		if (!this.MainMenu.activeSelf && !this.PauseMenu.activeSelf && !this.GameOverMenu.activeSelf)
		{
			if (this.touchControls.SwipeUp && this.Enemies.Count > 0 && this.ClosestEnemy().name == "BigEnemyClone")
			{
				this.score++;
				this.ClosestEnemy().GetComponent<Animator>().SetBool("BigZombieDeath", true);
				this.ClosestEnemy().GetComponent<Animator>().speed = 2f;
				this.ClosestEnemy().tag = "DeadZombie";
				this.audioSource.Play();
				base.StartCoroutine(this.EnemyDeath(this.ClosestEnemy()));
				this.BigEnemyDeathSound.Play();
				this.ClosestEnemy().GetComponent<Animator>().SetBool("isPunching", false);
			}
			if (this.touchControls.SwipeDown && this.Enemies.Count > 0 && this.ClosestEnemy().name == "MediumEnemyClone")
			{
				this.score++;
				this.ClosestEnemy().GetComponent<Animator>().SetBool("MediumZombieDeath", true);
				this.ClosestEnemy().GetComponent<Animator>().SetBool("isHoofing", false);
				this.ClosestEnemy().GetComponent<Animator>().speed = 2f;
				this.ClosestEnemy().tag = "DeadZombie";
				this.audioSource.Play();
				base.StartCoroutine(this.EnemyDeath(this.ClosestEnemy()));
				this.BigEnemyDeathSound.GetComponent<AudioSource>().enabled = true;
				this.MediumEnemyDeathSound.Play();
			}
			if (this.touchControls.Tap)
			{
				this.animator.SetBool("isPunchingLeft", true);
				return;
			}
			this.animator.SetBool("isPunchingLeft", false);
		}
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00003D0F File Offset: 0x00001F0F
	private GameObject ClosestEnemy()
	{
		return this.Enemies[0];
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00003D1D File Offset: 0x00001F1D
	private IEnumerator EnemyDeath(GameObject Enemy)
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(Enemy);
		yield break;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00003D2C File Offset: 0x00001F2C
	public void SaveGame()
	{
		PlayerPrefs.SetInt("Score", this.BestScore);
		PlayerPrefs.Save();
	}

	// Token: 0x040000A5 RID: 165
	public GameObject EnemyCollider;

	// Token: 0x040000A6 RID: 166
	public GameObject Menus;

	// Token: 0x040000A7 RID: 167
	public GameObject Player;

	// Token: 0x040000A8 RID: 168
	public GameObject audioSourceObject;

	// Token: 0x040000A9 RID: 169
	public GameObject MainMenu;

	// Token: 0x040000AA RID: 170
	public GameObject PauseMenu;

	// Token: 0x040000AB RID: 171
	public GameObject GameOverMenu;

	// Token: 0x040000AC RID: 172
	public GameObject CounterText;

	// Token: 0x040000AD RID: 173
	public GameObject NewHighscoreText;

	// Token: 0x040000AE RID: 174
	public GameOver gameOver;

	// Token: 0x040000AF RID: 175
	public TouchControl touchControls;

	// Token: 0x040000B0 RID: 176
	public Animator animator;

	// Token: 0x040000B1 RID: 177
	public List<GameObject> Enemies = new List<GameObject>();

	// Token: 0x040000B2 RID: 178
	public List<float> EnemiesPositionZ = new List<float>();

	// Token: 0x040000B3 RID: 179
	public float Distance;

	// Token: 0x040000B4 RID: 180
	public int score;

	// Token: 0x040000B5 RID: 181
	public int BestScore;

	// Token: 0x040000B6 RID: 182
	public AudioSource audioSource;

	// Token: 0x040000B7 RID: 183
	public AudioSource MediumEnemyDeathSound;

	// Token: 0x040000B8 RID: 184
	public AudioSource BigEnemyDeathSound;

	// Token: 0x040000B9 RID: 185
	public Text ScoreText;
}
