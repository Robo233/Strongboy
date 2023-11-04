using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
public class AnimationFixer : MonoBehaviour
{
	// Token: 0x0600000F RID: 15 RVA: 0x000021E8 File Offset: 0x000003E8
	private void Update()
	{
		base.gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
		base.gameObject.transform.position = new Vector3(2.5f, base.transform.position.y, base.transform.position.z);
	}
}
