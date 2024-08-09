using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200000E RID: 14
public class Settings : MonoBehaviour
{
	// Token: 0x06000047 RID: 71 RVA: 0x00003770 File Offset: 0x00001970
	private void Start()
	{
		this.PauseMenuHighscore.GetComponent<Text>().text = "Highscore: " + PlayerPrefs.GetInt("Score").ToString();
	}

	// Token: 0x06000048 RID: 72 RVA: 0x000037AC File Offset: 0x000019AC
	public void Back()
	{
		if (!this.CreditText.activeSelf)
		{
			this.OptionsMenu.SetActive(false);
			this.MainMenu.SetActive(true);
			this.SettingsButton.SetActive(true);
			return;
		}
		this.CreditText.SetActive(false);
		this.AdsButton.SetActive(true);
		this.RestoreButton.SetActive(true);
		this.CreditButton.SetActive(true);
		this.TutorialButton.SetActive(true);
		this.PauseMenuHighscore.SetActive(true);
		this.SFX.SetActive(true);
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00003840 File Offset: 0x00001A40
	public void Credits()
	{
		if (!this.CreditText.activeSelf)
		{
			this.CreditText.SetActive(true);
			this.AdsButton.SetActive(false);
			this.RestoreButton.SetActive(false);
			this.CreditButton.SetActive(false);
			this.TutorialButton.SetActive(false);
			this.PauseMenuHighscore.SetActive(false);
			this.SFX.SetActive(false);
			return;
		}
		this.CreditText.SetActive(false);
		this.AdsButton.SetActive(true);
		this.RestoreButton.SetActive(true);
		this.CreditButton.SetActive(true);
		this.TutorialButton.SetActive(true);
		this.SFX.SetActive(true);
	}

	// Token: 0x0600004A RID: 74 RVA: 0x000038F8 File Offset: 0x00001AF8
	public void Tutorial()
	{
		this.OptionsMenu.SetActive(false);
		this.NextButton.SetActive(true);
		this.TutorialCanvas.SetActive(true);
		this.TutorialText1.SetActive(true);
		this.BackButton.SetActive(true);
		this.Check.SetActive(false);
		this.PlaySymbol.SetActive(false);
	}

	// Token: 0x0600004B RID: 75 RVA: 0x0000395C File Offset: 0x00001B5C
	public void BackFromTutorial()
	{
		this.BackButtonTutorial.SetActive(false);
		this.TutorialCanvas.SetActive(false);
		this.OptionsMenu.SetActive(true);
		Menu.counter = 0;
		this.TutorialText1.SetActive(false);
		this.TutorialText2.SetActive(false);
		this.TutorialText3.SetActive(false);
		this.BackButtonTutorial.SetActive(false);
		this.LeftArrow.SetActive(true);
	}

	// Token: 0x0400008D RID: 141
	public GameObject SFX;

	// Token: 0x0400008E RID: 142
	public GameObject BackButton;

	// Token: 0x0400008F RID: 143
	public GameObject OptionsMenu;

	// Token: 0x04000090 RID: 144
	public GameObject MainMenu;

	// Token: 0x04000091 RID: 145
	public GameObject SettingsButton;

	// Token: 0x04000092 RID: 146
	public GameObject CreditText;

	// Token: 0x04000093 RID: 147
	public GameObject AdsButton;

	// Token: 0x04000094 RID: 148
	public GameObject RestoreButton;

	// Token: 0x04000095 RID: 149
	public GameObject CreditButton;

	// Token: 0x04000096 RID: 150
	public GameObject TutorialButton;

	// Token: 0x04000097 RID: 151
	public GameObject PauseMenuHighscore;

	// Token: 0x04000098 RID: 152
	public GameObject TutorialText1;

	// Token: 0x04000099 RID: 153
	public GameObject TutorialText2;

	// Token: 0x0400009A RID: 154
	public GameObject TutorialText3;

	// Token: 0x0400009B RID: 155
	public GameObject NextButton;

	// Token: 0x0400009C RID: 156
	public GameObject BackButtonTutorial;

	// Token: 0x0400009D RID: 157
	public GameObject MainMenuUI;

	// Token: 0x0400009E RID: 158
	public GameObject TutorialCanvas;

	// Token: 0x0400009F RID: 159
	public GameObject CreditCanvas;

	// Token: 0x040000A0 RID: 160
	public GameObject LeftArrow;

	// Token: 0x040000A1 RID: 161
	public GameObject PlaySymbol;

	// Token: 0x040000A2 RID: 162
	public GameObject Check;
}
