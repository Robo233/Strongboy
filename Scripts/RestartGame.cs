using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200000D RID: 13
public class RestartGame : MonoBehaviour
{
	// Token: 0x06000045 RID: 69 RVA: 0x0000373C File Offset: 0x0000193C
	public void RestartGameFunction()
	{
		this.ads.PlayAd();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	// Token: 0x0400008C RID: 140
	public AdsManager ads;
}
