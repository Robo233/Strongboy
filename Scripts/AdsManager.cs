using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

// Token: 0x02000002 RID: 2
public class AdsManager : MonoBehaviour, IUnityAdsListener
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private void Start()
	{
		Advertisement.Initialize("4459254");
		Advertisement.AddListener(this);
		this.ShowBanner();
		AdsManager.isAppPurchased = bool.Parse(PlayerPrefs.GetString("isAppPurchased"));
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000207C File Offset: 0x0000027C
	public void PlayAd()
	{
		if (Advertisement.IsReady("Interstitial_Android") && !AdsManager.isAppPurchased)
		{
			Advertisement.Show("Interstitial_Android");
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x0000209C File Offset: 0x0000029C
	public void PlayRewardedAd()
	{
		if (Advertisement.IsReady("Rewarded_Android"))
		{
			Advertisement.Show("Rewarded_Android");
			this.isAdvertisementReady = true;
			base.StartCoroutine(this.ReviveButtonOn());
			return;
		}
		this.AdsAreNotAvailableCanvas.SetActive(true);
		this.gameOverScreen.SetActive(false);
		Debug.Log("Rewarded ad is not ready");
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000020F6 File Offset: 0x000002F6
	public void ShowBanner()
	{
		if (Advertisement.IsReady("banner") && !AdsManager.isAppPurchased)
		{
			Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
			Advertisement.Banner.Show("banner");
			return;
		}
		base.StartCoroutine(this.RepeatShowBanner());
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002129 File Offset: 0x00000329
	public void HideBanner()
	{
		Advertisement.Banner.Hide(false);
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002131 File Offset: 0x00000331
	private IEnumerator RepeatShowBanner()
	{
		yield return new WaitForSeconds(1f);
		this.ShowBanner();
		yield break;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002140 File Offset: 0x00000340
	public void OnUnityAdsReady(string placementId)
	{
		Debug.Log("Ads are ready");
	}

	// Token: 0x06000008 RID: 8 RVA: 0x0000214C File Offset: 0x0000034C
	public void OnUnityAdsDidError(string message)
	{
		Debug.Log("Error: " + message);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x0000215E File Offset: 0x0000035E
	public void OnUnityAdsDidStart(string placementId)
	{
		Debug.Log("VIDEO STARTED");
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000216A File Offset: 0x0000036A
	public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
		{
			Debug.Log("PLAYER SHOULD NOT BE REWARDED");
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x00002187 File Offset: 0x00000387
	public void RemoveAdFunction()
	{
		AdsManager.isAppPurchased = true;
		GameOver.isAppPurchased = true;
		PlayerPrefs.SetString("isAppPurchased", AdsManager.isAppPurchased.ToString());
		PlayerPrefs.Save();
		this.HideBanner();
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000021B4 File Offset: 0x000003B4
	public void BackFromNoAds()
	{
		this.AdsAreNotAvailableCanvas.SetActive(false);
		this.gameOverScreen.SetActive(true);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000021CE File Offset: 0x000003CE
	private IEnumerator ReviveButtonOn()
	{
		yield return new WaitForSeconds(1f);
		this.ReviveButton.SetActive(true);
		this.WatchAdButton.SetActive(false);
		yield break;
	}

	// Token: 0x04000001 RID: 1
	private Action onRewardedAdSuccess;

	// Token: 0x04000002 RID: 2
	public static bool isAppPurchased;

	// Token: 0x04000003 RID: 3
	public bool isAdvertisementReady;

	// Token: 0x04000004 RID: 4
	public GameOver gameOver;

	// Token: 0x04000005 RID: 5
	public GameObject WatchAdButton;

	// Token: 0x04000006 RID: 6
	public GameObject ReviveButton;

	// Token: 0x04000007 RID: 7
	public GameObject AdsAreNotAvailableCanvas;

	// Token: 0x04000008 RID: 8
	public GameObject gameOverScreen;
}
