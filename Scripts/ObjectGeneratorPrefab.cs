using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Token: 0x0200000A RID: 10
public class ObjectGeneratorPrefab : MonoBehaviour
{
	// Token: 0x06000038 RID: 56 RVA: 0x000030E0 File Offset: 0x000012E0
	private void Start()
	{
		ObjectGeneratorPrefab.SpawnPoints = GameObject.FindGameObjectsWithTag(this.SpawnPoint);
		ObjectGeneratorPrefab.Objects = GameObject.FindGameObjectsWithTag(this.Object).ToList<GameObject>();
		ObjectGeneratorPrefab.NonStaticObjects = GameObject.FindGameObjectsWithTag(this.NonStaticObject).ToList<GameObject>();
		for (int i = 0; i < ObjectGeneratorPrefab.Objects.Count; i++)
		{
			ObjectGeneratorPrefab.Objects[i].GetComponent<Renderer>().enabled = true;
		}
		if (this.RandomizatorOn)
		{
			for (int j = 0; j < ObjectGeneratorPrefab.NonStaticObjects.Count; j++)
			{
				ObjectGeneratorPrefab.NonStaticObjects[j].transform.rotation = Quaternion.Euler(0f, (float)Random.Range(0, 180), 0f);
				if (ObjectGeneratorPrefab.NonStaticObjects[j].name != "rock")
				{
					ObjectGeneratorPrefab.NonStaticObjects[j].transform.localScale = new Vector3((float)Random.Range(5, 10), (float)Random.Range(5, 8), (float)Random.Range(5, 10));
				}
			}
		}
	}

	// Token: 0x06000039 RID: 57 RVA: 0x000031F8 File Offset: 0x000013F8
	private void Update()
	{
		this.RandomNumber = Random.Range(0, ObjectGeneratorPrefab.Objects.Count);
		this.RandomNumberSpawnPoints = Random.Range(0, ObjectGeneratorPrefab.SpawnPoints.Length);
		this.timer -= Time.deltaTime;
		if (this.timer <= 0f)
		{
			this.timer = this.timeUntilNextObjectIsSpawned;
			base.StartCoroutine(this.Generator());
		}
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00003266 File Offset: 0x00001466
	private IEnumerator Generator()
	{
		yield return new WaitForSeconds(0f);
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(ObjectGeneratorPrefab.Objects[this.RandomNumber]);
		gameObject.transform.position = ObjectGeneratorPrefab.SpawnPoints[this.RandomNumberSpawnPoints].transform.position;
		gameObject.AddComponent<ObjectMovement>();
		gameObject.GetComponent<ObjectMovement>().Distance = this.Distance;
		gameObject.GetComponent<ObjectMovement>().DestoryWhenPositionIsBelow = this.DestoryWhenPositionIsBelow;
		gameObject.GetComponent<ObjectMovement>().DestroyAtPosition = this.DestroyAtPosition;
		gameObject.tag = "Prefab";
		gameObject.name = ObjectGeneratorPrefab.Objects[this.RandomNumber].name;
		if (this.RandomizatorOn)
		{
			gameObject.transform.rotation = Quaternion.Euler(0f, (float)Random.Range(0, 180), 0f);
			if (gameObject.name != "rock")
			{
				gameObject.transform.localScale = new Vector3((float)Random.Range(1, 10), (float)Random.Range(5, 8), (float)Random.Range(5, 10));
			}
		}
		yield break;
	}

	// Token: 0x04000061 RID: 97
	public string SpawnPoint;

	// Token: 0x04000062 RID: 98
	public string Object;

	// Token: 0x04000063 RID: 99
	public string NonStaticObject;

	// Token: 0x04000064 RID: 100
	public string DestroyAtPosition;

	// Token: 0x04000065 RID: 101
	public static GameObject[] SpawnPoints;

	// Token: 0x04000066 RID: 102
	public static List<GameObject> Objects = new List<GameObject>();

	// Token: 0x04000067 RID: 103
	public static List<GameObject> NonStaticObjects = new List<GameObject>();

	// Token: 0x04000068 RID: 104
	public int RandomNumber;

	// Token: 0x04000069 RID: 105
	private int RandomNumberSpawnPoints;

	// Token: 0x0400006A RID: 106
	private float timer;

	// Token: 0x0400006B RID: 107
	public float timeUntilNextObjectIsSpawned;

	// Token: 0x0400006C RID: 108
	public float DestoryWhenPositionIsBelow;

	// Token: 0x0400006D RID: 109
	public bool RandomizatorOn;

	// Token: 0x0400006E RID: 110
	public Vector3 Distance = new Vector3(0f, 0f, 0f);
}
