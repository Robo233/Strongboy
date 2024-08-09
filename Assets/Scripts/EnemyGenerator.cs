using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000005 RID: 5
public class EnemyGenerator : MonoBehaviour
{
	// Token: 0x06000019 RID: 25 RVA: 0x0000246A File Offset: 0x0000066A
	private void Start()
	{
		this.EnemyGeneratorAtTheBeginning(this.BigEnemy, 482f);
		this.EnemyGeneratorAtTheBeginning(this.MediumEnemy, 282f);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x0000248E File Offset: 0x0000068E
	private void Update()
	{
		this.timeUntilNextEnemyIsSpawned -= this.timeDecrease;
		this.EnemyGeneratorFunction();
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000024AC File Offset: 0x000006AC
	private void EnemyGeneratorFunction()
	{
		this.RandomNumber = Random.Range(0, 3);
		if (this.RandomNumber == 0)
		{
			this.timer -= Time.deltaTime;
			if (this.timer <= 0f)
			{
				this.timer = this.timeUntilNextEnemyIsSpawned;
				base.StartCoroutine(this.BigEnemyGenerator());
			}
		}
		if (this.RandomNumber == 1)
		{
			this.timer -= Time.deltaTime;
			if (this.timer <= 0f)
			{
				this.timer = this.timeUntilNextEnemyIsSpawned;
				base.StartCoroutine(this.MediumEnemyGenerator());
			}
		}
		if (this.RandomNumber == 2)
		{
			this.timer -= Time.deltaTime;
			if (this.timer <= 0f)
			{
				this.timer = this.timeUntilNextEnemyIsSpawned;
				base.StartCoroutine(this.SmallEnemyGenerator());
			}
		}
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002588 File Offset: 0x00000788
	private void EnemyGeneratorAtTheBeginning(GameObject Enemy, float z)
	{
		if (Enemy == this.BigEnemy)
		{
			GameObject gameObject = Object.Instantiate<GameObject>(Enemy);
			gameObject.transform.position = new Vector3(2.5f, 1.36f, z);
			gameObject.name = "BigEnemyClone";
		}
		if (Enemy == this.MediumEnemy)
		{
			GameObject gameObject2 = Object.Instantiate<GameObject>(Enemy);
			gameObject2.transform.position = new Vector3(2.5f, 1.36f, z);
			gameObject2.name = "MediumEnemyClone";
		}
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00002607 File Offset: 0x00000807
	private IEnumerator BigEnemyGenerator()
	{
		yield return new WaitForSeconds(2f);
		GameObject gameObject = Object.Instantiate<GameObject>(this.BigEnemy);
		gameObject.transform.position = this.SpawnPoint;
		gameObject.name = "BigEnemyClone";
		yield break;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00002616 File Offset: 0x00000816
	private IEnumerator MediumEnemyGenerator()
	{
		yield return new WaitForSeconds(2f);
		GameObject gameObject = Object.Instantiate<GameObject>(this.MediumEnemy);
		gameObject.transform.position = this.SpawnPoint;
		gameObject.name = "MediumEnemyClone";
		yield break;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002625 File Offset: 0x00000825
	private IEnumerator SmallEnemyGenerator()
	{
		yield return new WaitForSeconds(2f);
		GameObject gameObject = Object.Instantiate<GameObject>(this.SmallEnemy);
		gameObject.transform.position = this.SpawnPoint;
		gameObject.name = "SmallEnemyClone";
		yield break;
	}

	// Token: 0x04000011 RID: 17
	public GameObject BigEnemy;

	// Token: 0x04000012 RID: 18
	public GameObject MediumEnemy;

	// Token: 0x04000013 RID: 19
	public GameObject SmallEnemy;

	// Token: 0x04000014 RID: 20
	private int RandomNumber;

	// Token: 0x04000015 RID: 21
	public float timeUntilNextEnemyIsSpawned = 3f;

	// Token: 0x04000016 RID: 22
	private float timeDecrease = 0.0001f;

	// Token: 0x04000017 RID: 23
	private float timer = 0.1f;

	// Token: 0x04000018 RID: 24
	public Vector3 SpawnPoint;
}
