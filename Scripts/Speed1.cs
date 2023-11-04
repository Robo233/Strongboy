using System;
using UnityEngine;

// Token: 0x0200000F RID: 15
public class Speed : MonoBehaviour
{
	// Token: 0x0600004D RID: 77 RVA: 0x000039D7 File Offset: 0x00001BD7
	private void Update()
	{
		this.SpeedValue += this.SpeedIncrease;
	}

	// Token: 0x040000A3 RID: 163
	public float SpeedValue = 0.01f;

	// Token: 0x040000A4 RID: 164
	public float SpeedIncrease = 0.0001f;
}
