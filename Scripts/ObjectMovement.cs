using System;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class ObjectMovement : MonoBehaviour
{
	// Token: 0x0600003D RID: 61 RVA: 0x000032B0 File Offset: 0x000014B0
	private void Start()
	{
		this.Targets = GameObject.FindGameObjectsWithTag("Target");
		this.TargetPositions = new float[this.Targets.Length];
		this.SceneLoader = GameObject.Find("SceneLoader");
		this.speed = this.SceneLoader.GetComponent<Speed>();
		this.objectGeneratorPrefab = this.SceneLoader.GetComponent<ObjectGeneratorPrefab>();
		base.transform.position + this.Distance;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x0000332C File Offset: 0x0000152C
	private void FixedUpdate()
	{
		Vector3 position = base.transform.position;
		Vector3 target = position + this.Distance;
		base.transform.position = Vector3.MoveTowards(position, target, this.speedOfObject);
		this.ObjectDestroyer();
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00003370 File Offset: 0x00001570
	private void ObjectDestroyer()
	{
		if (this.DestroyAtPosition == "z")
		{
			if (base.gameObject.transform.position.z < this.DestoryWhenPositionIsBelow)
			{
				ObjectGeneratorPrefab.Objects.Remove(base.gameObject);
				Object.Destroy(base.gameObject);
				return;
			}
		}
		else if (this.DestroyAtPosition == "x")
		{
			if (base.gameObject.transform.position.x < this.DestoryWhenPositionIsBelow)
			{
				ObjectGeneratorPrefab.Objects.Remove(base.gameObject);
				Object.Destroy(base.gameObject);
				return;
			}
		}
		else if (base.gameObject.transform.position.y < this.DestoryWhenPositionIsBelow)
		{
			ObjectGeneratorPrefab.Objects.Remove(base.gameObject);
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400006F RID: 111
	private int RandomNumber;

	// Token: 0x04000070 RID: 112
	private int temp1;

	// Token: 0x04000071 RID: 113
	private int temp2;

	// Token: 0x04000072 RID: 114
	private GameObject[] Targets;

	// Token: 0x04000073 RID: 115
	private float[] TargetPositions;

	// Token: 0x04000074 RID: 116
	public float speedOfObject = 1f;

	// Token: 0x04000075 RID: 117
	public float DestoryWhenPositionIsBelow;

	// Token: 0x04000076 RID: 118
	private GameObject SceneLoader;

	// Token: 0x04000077 RID: 119
	private Speed speed;

	// Token: 0x04000078 RID: 120
	private ObjectGeneratorPrefab objectGeneratorPrefab;

	// Token: 0x04000079 RID: 121
	public Vector3 Distance = new Vector3(0f, 0f, 0f);

	// Token: 0x0400007A RID: 122
	public string DestroyAtPosition;
}
