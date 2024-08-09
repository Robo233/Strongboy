using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
public class EnemyMovement : MonoBehaviour
{
	// Token: 0x06000021 RID: 33 RVA: 0x00002660 File Offset: 0x00000860
	private void Start()
	{
		this.SceneLoader = GameObject.Find("SceneLoader");
		this.target = GameObject.Find("Target");
		this.speedd = this.SceneLoader.GetComponent<Speed>();
		this.Player = GameObject.Find("Strongboy");
	}

	// Token: 0x06000022 RID: 34 RVA: 0x000026B0 File Offset: 0x000008B0
	private void FixedUpdate()
	{
		Vector3 position = base.transform.position;
		Vector3 position2 = this.target.transform.position;
		base.transform.position = Vector3.MoveTowards(position, position2, this.speedd.SpeedValue);
	}

	// Token: 0x04000019 RID: 25
	public GameObject target;

	// Token: 0x0400001A RID: 26
	public GameObject Player;

	// Token: 0x0400001B RID: 27
	public GameObject SceneLoader;

	// Token: 0x0400001C RID: 28
	private Speed speedd;

	// Token: 0x0400001D RID: 29
	private Vector3 b;
}
