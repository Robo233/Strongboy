using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000009 RID: 9
public class Mute : MonoBehaviour
{
	// Token: 0x06000035 RID: 53 RVA: 0x00002FB4 File Offset: 0x000011B4
	private void Start()
	{
		this.isMuted = PlayerPrefs.GetString("SavedString");
		if (this.isMuted == "Muted")
		{
			this.RawImagePauseMenu.texture = this.MuteTexure;
			this.RawImageSettingsMenu.texture = this.MuteTexure;
			AudioListener.volume = 0f;
			return;
		}
		this.RawImagePauseMenu.texture = this.SoundTexure;
		this.RawImageSettingsMenu.texture = this.SoundTexure;
		AudioListener.volume = 1f;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x0000303C File Offset: 0x0000123C
	public void MuteFunction()
	{
		if (this.RawImagePauseMenu.texture == this.MuteTexure)
		{
			this.RawImagePauseMenu.texture = this.SoundTexure;
			this.RawImageSettingsMenu.texture = this.SoundTexure;
			PlayerPrefs.SetString("SavedString", "UnMuted");
			AudioListener.volume = 1f;
			return;
		}
		this.RawImagePauseMenu.texture = this.MuteTexure;
		this.RawImageSettingsMenu.texture = this.MuteTexure;
		PlayerPrefs.SetString("SavedString", "Muted");
		AudioListener.volume = 0f;
	}

	// Token: 0x0400005A RID: 90
	public RawImage RawImagePauseMenu;

	// Token: 0x0400005B RID: 91
	public RawImage RawImageSettingsMenu;

	// Token: 0x0400005C RID: 92
	public GameObject PauseMenuSoundButton;

	// Token: 0x0400005D RID: 93
	public GameObject SettingsMenuSoundButton;

	// Token: 0x0400005E RID: 94
	public Texture SoundTexure;

	// Token: 0x0400005F RID: 95
	public Texture MuteTexure;

	// Token: 0x04000060 RID: 96
	public string isMuted;
}
