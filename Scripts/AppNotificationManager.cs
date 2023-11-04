using System;
using System.Text;
using NotificationSamples;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000004 RID: 4
public class AppNotificationManager : MonoBehaviour
{
	// Token: 0x06000011 RID: 17 RVA: 0x0000225B File Offset: 0x0000045B
	private void Start()
	{
		this.InitializeGameChannel();
		this.ScheduleNotificationForUnactivity();
		this.DisplayPendingNotification();
	}

	// Token: 0x06000012 RID: 18 RVA: 0x0000226F File Offset: 0x0000046F
	private void Update()
	{
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00002274 File Offset: 0x00000474
	private void InitializeGameChannel()
	{
		GameNotificationChannel gameNotificationChannel = new GameNotificationChannel("notification_channel_id", "Smash some zombies!", "Notification from Strongboy");
		this.manager.Initialize(new GameNotificationChannel[]
		{
			gameNotificationChannel
		});
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000022B0 File Offset: 0x000004B0
	private void ScheduleNotificationForUnactivity()
	{
		this.manager.CancelAllNotifications();
		this.ScheduleNotificationForUnactivity(3);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x000022C4 File Offset: 0x000004C4
	private void ScheduleNotificationForUnactivity(int daysIncrement)
	{
		string title = "Smash some zombies!";
		string body = "Notification from Strongboy";
		DateTime deliveryTime = DateTime.UtcNow.AddDays((double)daysIncrement);
		string channelId = "notification_channel_id";
		this.SendNotification(title, body, deliveryTime, null, false, channelId, this.smallIconName, this.largeIconName);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002318 File Offset: 0x00000518
	public void SendNotification(string title, string body, DateTime deliveryTime, int? badgeNumber = null, bool reschedule = false, string channelId = null, string smallIcon = null, string largeIcon = null)
	{
		IGameNotification gameNotification = this.manager.CreateNotification();
		if (gameNotification == null)
		{
			return;
		}
		gameNotification.Title = title;
		gameNotification.Body = body;
		gameNotification.Group = ((!string.IsNullOrEmpty(channelId)) ? channelId : "notification_channel_id");
		gameNotification.DeliveryTime = new DateTime?(deliveryTime);
		gameNotification.SmallIcon = smallIcon;
		gameNotification.LargeIcon = largeIcon;
		if (badgeNumber != null)
		{
			gameNotification.BadgeNumber = badgeNumber;
		}
		this.manager.ScheduleNotification(gameNotification).Reschedule = reschedule;
		Debug.Log(string.Format("Queued notification for unactivity with ID \"{0}\" at time {1:dd.MM.yyyy HH:mm:ss}", gameNotification.Id, deliveryTime));
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000023BC File Offset: 0x000005BC
	private void DisplayPendingNotification()
	{
		StringBuilder stringBuilder = new StringBuilder("Pending notifications at:");
		stringBuilder.AppendLine();
		for (int i = this.manager.PendingNotifications.Count - 1; i >= 0; i--)
		{
			DateTime? deliveryTime = this.manager.PendingNotifications[i].Notification.DeliveryTime;
			if (deliveryTime != null)
			{
				stringBuilder.Append(string.Format("{0:dd.MM.yyyy HH:mm:ss}", deliveryTime));
				stringBuilder.AppendLine();
			}
		}
		this.notificationScheduledText.text = stringBuilder.ToString();
	}

	// Token: 0x04000009 RID: 9
	[SerializeField]
	[Tooltip("Reference to the notification manager.")]
	public GameNotificationsManager manager;

	// Token: 0x0400000A RID: 10
	[SerializeField]
	public Text notificationScheduledText;

	// Token: 0x0400000B RID: 11
	private const string NOTIFICATION_CHANNEL_ID = "notification_channel_id";

	// Token: 0x0400000C RID: 12
	private const string GAME_NOTIFICATION_CHANNEL_TITLE = "Smash some zombies!";

	// Token: 0x0400000D RID: 13
	private const string GAME_NOTIFICATION_CHANNEL_DESCRIPTION = "Notification from Strongboy";

	// Token: 0x0400000E RID: 14
	private const int DISPLAY_NOTIFICATION_AFTER_DAYS = 3;

	// Token: 0x0400000F RID: 15
	private string smallIconName = "icon_0";

	// Token: 0x04000010 RID: 16
	private string largeIconName = "icon_1";
}
