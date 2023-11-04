using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x02000008 RID: 8
public class Menu : MonoBehaviour
{
	// Token: 0x06000029 RID: 41 RVA: 0x000029C0 File Offset: 0x00000BC0
	private void Start()
	{
		this.Prefabs = GameObject.FindGameObjectsWithTag("Prefab");
		this.Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		this.objectGeneratorPrefab = base.GetComponent<ObjectGeneratorPrefab>();
		this.speed = base.GetComponent<Speed>();
		if (PlayerPrefs.GetString("TutorialsOn") == "true")
		{
			this.toggle.GetComponent<Toggle>().isOn = true;
		}
		else
		{
			this.toggle.GetComponent<Toggle>().isOn = false;
		}
		if (PlayerPrefs.GetString("SandstormOn") == "True")
		{
			this.Sandstormtoggle.GetComponent<Toggle>().isOn = true;
			this.SandStorm.SetActive(true);
		}
		else
		{
			this.Sandstormtoggle.GetComponent<Toggle>().isOn = false;
			this.SandStorm.SetActive(false);
		}
		if (PlayerPrefs.GetString("ShadowsOn") == "True")
		{
			this.Shadowstoggle.GetComponent<Toggle>().isOn = true;
			Debug.Log("Shadow on");
			QualitySettings.shadows = ShadowQuality.All;
			return;
		}
		this.Shadowstoggle.GetComponent<Toggle>().isOn = false;
		Debug.Log("Shadow off");
		QualitySettings.shadows = ShadowQuality.Disable;
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002AEC File Offset: 0x00000CEC
	public void Playgame()
	{
		this.pause.isPlaying = true;
		PlayerPrefs.Save();
		this.MainMenu.SetActive(false);
		this.ads.ShowBanner();
		this.Camera.GetComponent<AudioSource>().enabled = true;
		this.Player.GetComponent<AudioSource>().enabled = true;
		for (int i = 0; i < this.Prefabs.Length; i++)
		{
			this.Prefabs[i].GetComponent<ObjectMovement>().enabled = true;
		}
		for (int j = 0; j < this.Roads.Length; j++)
		{
			this.Roads[j].GetComponent<ObjectMovement>().enabled = true;
		}
		for (int k = 0; k < this.Enemies.Length; k++)
		{
			this.Enemies[k].GetComponent<EnemyMovement>().enabled = true;
		}
		base.gameObject.GetComponent<ObjectGeneratorPrefab>().enabled = true;
		base.gameObject.GetComponent<EnemyGenerator>().enabled = true;
		base.gameObject.GetComponent<Speed>().enabled = true;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002BE8 File Offset: 0x00000DE8
	public void Play()
	{
		this.isPlaying = true;
		this.MainMenuUI.SetActive(false);
		this.SettingsButton.SetActive(false);
		this.NextButton.SetActive(true);
		this.MainMenu.SetActive(false);
		this.BackFromTutorial.SetActive(false);
		this.PlaySymbol.SetActive(false);
		this.Check.SetActive(false);
		if (this.toggle.GetComponent<Toggle>().isOn)
		{
			this.TutorialCanvas.SetActive(true);
			this.TutorialText1.SetActive(true);
			return;
		}
		this.Playgame();
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002C84 File Offset: 0x00000E84
	public void Next()
	{
		if (Menu.counter == 0)
		{
			this.BackButton.SetActive(true);
			this.TutorialText1.SetActive(false);
			this.TutorialText2.SetActive(true);
			Menu.counter++;
			return;
		}
		if (Menu.counter != 1)
		{
			if (Menu.counter == 2)
			{
				if (this.isPlaying)
				{
					this.Playgame();
					this.TutorialCanvas.SetActive(false);
				}
				else
				{
					this.TutorialText3.SetActive(false);
					this.NextButton.SetActive(false);
					this.BackButton.SetActive(false);
					this.SFX.SetActive(true);
					this.RemoveAds.SetActive(true);
					this.RestorePurchases.SetActive(true);
					this.Credits.SetActive(true);
					this.Tutorial.SetActive(true);
					this.TutorialCanvas.SetActive(false);
					this.OptionsMenu.SetActive(true);
				}
				Menu.counter = 0;
				this.LeftArrow.SetActive(true);
				this.PlaySymbol.SetActive(false);
				this.Check.SetActive(false);
			}
			return;
		}
		this.TutorialText2.SetActive(false);
		this.TutorialText3.SetActive(true);
		Menu.counter++;
		if (this.isPlaying)
		{
			this.PlaySymbol.SetActive(true);
			this.LeftArrow.SetActive(false);
			return;
		}
		this.Check.SetActive(true);
		this.LeftArrow.SetActive(false);
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002DF8 File Offset: 0x00000FF8
	public void Back()
	{
		if (Menu.counter == 2)
		{
			this.LeftArrow.SetActive(true);
			this.PlaySymbol.SetActive(false);
			this.Check.SetActive(false);
			this.TutorialText3.SetActive(false);
			this.TutorialText2.SetActive(true);
			Menu.counter--;
			return;
		}
		if (Menu.counter == 1)
		{
			this.TutorialText1.SetActive(true);
			this.TutorialText2.SetActive(false);
			Menu.counter--;
			this.BackButton.SetActive(false);
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002E8E File Offset: 0x0000108E
	public void Quitgame()
	{
		Application.Quit();
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00002E98 File Offset: 0x00001098
	public void MainMenuback()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		Time.timeScale = 1f;
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002EC1 File Offset: 0x000010C1
	public void TutorialFunction()
	{
		if (this.toggle.GetComponent<Toggle>().isOn)
		{
			PlayerPrefs.SetString("TutorialsOn", "true");
		}
		else
		{
			PlayerPrefs.SetString("TutorialsOn", "false");
		}
		PlayerPrefs.Save();
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00002EFC File Offset: 0x000010FC
	public void SandStormOn()
	{
		if (this.Sandstormtoggle.GetComponent<Toggle>().isOn)
		{
			PlayerPrefs.SetString("SandstormOn", "True");
			this.SandStorm.SetActive(true);
		}
		else
		{
			PlayerPrefs.SetString("SandstormOn", "False");
			this.SandStorm.SetActive(false);
		}
		PlayerPrefs.Save();
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002F58 File Offset: 0x00001158
	public void ShadowsOn()
	{
		if (this.Shadowstoggle.GetComponent<Toggle>().isOn)
		{
			PlayerPrefs.SetString("ShadowsOn", "True");
			QualitySettings.shadows = ShadowQuality.All;
		}
		else
		{
			PlayerPrefs.SetString("ShadowsOn", "False");
			QualitySettings.shadows = ShadowQuality.Disable;
		}
		PlayerPrefs.Save();
	}

	// Token: 0x04000034 RID: 52
	public GameObject MainMenu;

	// Token: 0x04000035 RID: 53
	public GameObject MainMenuUI;

	// Token: 0x04000036 RID: 54
	public GameObject SettingsButton;

	// Token: 0x04000037 RID: 55
	public GameObject TutorialText1;

	// Token: 0x04000038 RID: 56
	public GameObject TutorialText2;

	// Token: 0x04000039 RID: 57
	public GameObject TutorialText3;

	// Token: 0x0400003A RID: 58
	public GameObject NextButton;

	// Token: 0x0400003B RID: 59
	public GameObject BackButton;

	// Token: 0x0400003C RID: 60
	public GameObject Camera;

	// Token: 0x0400003D RID: 61
	public GameObject Player;

	// Token: 0x0400003E RID: 62
	public GameObject SFX;

	// Token: 0x0400003F RID: 63
	public GameObject RemoveAds;

	// Token: 0x04000040 RID: 64
	public GameObject RestorePurchases;

	// Token: 0x04000041 RID: 65
	public GameObject Credits;

	// Token: 0x04000042 RID: 66
	public GameObject Tutorial;

	// Token: 0x04000043 RID: 67
	public GameObject OptionsMenu;

	// Token: 0x04000044 RID: 68
	public GameObject SceneLoader;

	// Token: 0x04000045 RID: 69
	public GameObject TutorialCanvas;

	// Token: 0x04000046 RID: 70
	public GameObject LeftArrow;

	// Token: 0x04000047 RID: 71
	public GameObject PlaySymbol;

	// Token: 0x04000048 RID: 72
	public GameObject Check;

	// Token: 0x04000049 RID: 73
	public GameObject BackFromTutorial;

	// Token: 0x0400004A RID: 74
	public GameObject SandStorm;

	// Token: 0x0400004B RID: 75
	public GameObject[] Prefabs;

	// Token: 0x0400004C RID: 76
	public GameObject[] Enemies;

	// Token: 0x0400004D RID: 77
	public GameObject[] Roads;

	// Token: 0x0400004E RID: 78
	public EnemyGenerator enemyGenerator;

	// Token: 0x0400004F RID: 79
	private ObjectGeneratorPrefab objectGeneratorPrefab;

	// Token: 0x04000050 RID: 80
	private Speed speed;

	// Token: 0x04000051 RID: 81
	public AdsManager ads;

	// Token: 0x04000052 RID: 82
	public Pause pause;

	// Token: 0x04000053 RID: 83
	public static int counter;

	// Token: 0x04000054 RID: 84
	public bool isPlaying;

	// Token: 0x04000055 RID: 85
	public string isSandstorm;

	// Token: 0x04000056 RID: 86
	public Toggle toggle;

	// Token: 0x04000057 RID: 87
	public Toggle Sandstormtoggle;

	// Token: 0x04000058 RID: 88
	public Toggle Shadowstoggle;

	// Token: 0x04000059 RID: 89
	public LightShadows shadows;
}
