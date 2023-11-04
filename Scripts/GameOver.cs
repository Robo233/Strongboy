using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000007 RID: 7
public class GameOver : MonoBehaviour
{
	// Token: 0x06000024 RID: 36 RVA: 0x000026FF File Offset: 0x000008FF
	private void Awake()
	{
		this.isGamePaused = false;
		this.BestScore = PlayerPrefs.GetInt("Score");
		this.ads.ShowBanner();
		GameOver.isAppPurchased = bool.Parse(PlayerPrefs.GetString("isAppPurchased"));
	}

	// Token: 0x06000025 RID: 37 RVA: 0x00002738 File Offset: 0x00000938
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
			this.GameOverMenu.SetActive(true);
			this.currentSpeed = this.speed.SpeedValue;
			this.speed.SpeedValue = 0f;
			this.speed.SpeedIncrease = 0f;
			this.enemyGenerator.enabled = false;
			this.isGamePaused = true;
			if (GameOver.isAppPurchased)
			{
				this.ReviveButton.SetActive(true);
				this.WatchAdButton.SetActive(false);
			}
			else
			{
				this.WatchAdButton.SetActive(true);
				this.ReviveButton.SetActive(false);
			}
			this.Enemy = other.gameObject;
			Object.Destroy(this.Enemy);
			this.Camera.GetComponent<AudioSource>().enabled = false;
			this.Player.GetComponent<AudioSource>().enabled = false;
			base.gameObject.GetComponent<AudioSource>().enabled = true;
			Text scoreText = this.ScoreText;
			scoreText.text += this.swipeTest.score.ToString();
			Text bestText = this.BestText;
			bestText.text += this.BestScore.ToString();
			this.Prefabs = GameObject.FindGameObjectsWithTag("Prefab");
			for (int i = 0; i < this.Prefabs.Length; i++)
			{
				this.Prefabs[i].GetComponent<ObjectMovement>().enabled = false;
			}
		}
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000028AA File Offset: 0x00000AAA
	public void WatchAdd()
	{
		this.ads.PlayRewardedAd();
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000028B8 File Offset: 0x00000AB8
	public void onRewardedAdSuccess()
	{
		if (this.GameOverMenu)
		{
			this.GameOverMenu.SetActive(false);
		}
		if (this.enemyGenerator)
		{
			this.enemyGenerator.enabled = true;
		}
		this.speed.SpeedValue = this.currentSpeed;
		this.speed.SpeedIncrease = 0.0001f;
		this.ScoreText.text = "Score:";
		this.BestText.text = "Best:";
		this.swipeTest.score++;
		this.Camera.GetComponent<AudioSource>().enabled = true;
		this.Player.GetComponent<AudioSource>().enabled = true;
		base.gameObject.GetComponent<AudioSource>().enabled = false;
		this.swipeTest.score++;
		for (int i = 0; i < this.Prefabs.Length; i++)
		{
			this.Prefabs[i].GetComponent<ObjectMovement>().enabled = true;
		}
	}

	// Token: 0x0400001E RID: 30
	public GameObject Camera;

	// Token: 0x0400001F RID: 31
	public GameObject Player;

	// Token: 0x04000020 RID: 32
	public GameObject GameOverMenu;

	// Token: 0x04000021 RID: 33
	public GameObject SceneLoader;

	// Token: 0x04000022 RID: 34
	public GameObject NewHighscoreText;

	// Token: 0x04000023 RID: 35
	public GameObject WatchAdButton;

	// Token: 0x04000024 RID: 36
	public GameObject ReviveButton;

	// Token: 0x04000025 RID: 37
	public GameObject CounterText;

	// Token: 0x04000026 RID: 38
	private GameObject Enemy;

	// Token: 0x04000027 RID: 39
	public GameObject[] Prefabs;

	// Token: 0x04000028 RID: 40
	public int BestScore;

	// Token: 0x04000029 RID: 41
	public bool isGamePaused;

	// Token: 0x0400002A RID: 42
	public static bool isAppPurchased;

	// Token: 0x0400002B RID: 43
	public SwipeTest swipeTest;

	// Token: 0x0400002C RID: 44
	public Speed speed;

	// Token: 0x0400002D RID: 45
	public EnemyGenerator enemyGenerator;

	// Token: 0x0400002E RID: 46
	public ObjectGeneratorPrefab objectGeneratorPrefab;

	// Token: 0x0400002F RID: 47
	public AdsManager ads;

	// Token: 0x04000030 RID: 48
	public Text ScoreText;

	// Token: 0x04000031 RID: 49
	public Text BestText;

	// Token: 0x04000032 RID: 50
	private float currentSpeed;

	// Token: 0x04000033 RID: 51
	private Vector3 CounterTextPosition2;
}
