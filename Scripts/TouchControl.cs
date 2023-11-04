using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000011 RID: 17
public class TouchControl : MonoBehaviour
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000056 RID: 86 RVA: 0x00003D8B File Offset: 0x00001F8B
	public Vector2 SwipeDelta
	{
		get
		{
			return this.swipeDelta;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000057 RID: 87 RVA: 0x00003D93 File Offset: 0x00001F93
	public bool Tap
	{
		get
		{
			return this.tap;
		}
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000058 RID: 88 RVA: 0x00003D9B File Offset: 0x00001F9B
	public bool SwipeUp
	{
		get
		{
			return this.swipeUp;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000059 RID: 89 RVA: 0x00003DA3 File Offset: 0x00001FA3
	public bool SwipeDown
	{
		get
		{
			return this.swipeDown;
		}
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00003DAC File Offset: 0x00001FAC
	private void Update()
	{
		this.Enemies = GameObject.FindGameObjectsWithTag("Enemy").ToList<GameObject>().FindAll((GameObject x) => Vector3.Distance(this.Player.transform.position, x.transform.position) < this.swipeTest.Distance);
		if (this.Enemies.Count > 0)
		{
			if (!this.PunchSign.activeSelf)
			{
				this.PunchSign.SetActive(true);
				this.Arrow.GetComponent<RawImage>().enabled = true;
			}
			if (this.ClosestEnemy().name == "MediumEnemyClone")
			{
				this.Arrow.GetComponent<RawImage>().texture = this.ArrowDownTexture;
			}
			else if (this.ClosestEnemy().name == "BigEnemyClone")
			{
				this.Arrow.GetComponent<RawImage>().texture = this.ArrowUpTexture;
			}
			else
			{
				this.Arrow.GetComponent<RawImage>().enabled = false;
			}
		}
		else if (this.PunchSign)
		{
			this.PunchSign.SetActive(false);
			this.Arrow.GetComponent<RawImage>().enabled = false;
		}
		if (this.Enemies.Count > 0 && Math.Abs(Math.Abs(this.Player.transform.position.z) - Math.Abs(this.ClosestEnemy().transform.position.z)) < 4f)
		{
			if (this.ClosestEnemy().name == "BigEnemyClone")
			{
				this.ClosestEnemy().GetComponent<Animator>().SetBool("isPunching", true);
			}
			if (this.ClosestEnemy().name == "MediumEnemyClone")
			{
				this.ClosestEnemy().GetComponent<Animator>().SetBool("isHoofing", true);
			}
			if (this.ClosestEnemy().name == "SmallEnemyClone")
			{
				this.ClosestEnemy().GetComponent<Animator>().SetBool("isHooking", true);
			}
		}
		this.tap = (this.swipeUp = (this.swipeDown = false));
		if (Input.GetMouseButtonDown(0))
		{
			this.tap = true;
			this.isDraging = true;
			this.startTouch = Input.mousePosition;
		}
		else if (Input.GetMouseButtonUp(0))
		{
			this.isDraging = false;
			this.Reset();
		}
		if (Input.touches.Length != 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				this.isDraging = true;
				this.startTouch = Input.touches[0].position;
			}
			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				this.isDraging = false;
				this.Reset();
			}
		}
		this.swipeDelta = Vector2.zero;
		if (this.isDraging)
		{
			if (Input.touches.Length != 0)
			{
				this.swipeDelta = Input.touches[0].position - this.startTouch;
			}
			else if (Input.GetMouseButton(0))
			{
				this.swipeDelta = Input.mousePosition - this.startTouch;
			}
		}
		if (this.swipeDelta.magnitude > 40f)
		{
			float x2 = this.swipeDelta.x;
			float y = this.swipeDelta.y;
			if (Mathf.Abs(x2) <= Mathf.Abs(y))
			{
				if (y < 0f)
				{
					this.swipeDown = true;
					this.tap = false;
				}
				else
				{
					this.swipeUp = true;
					this.tap = false;
				}
			}
			this.Reset();
		}
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00004118 File Offset: 0x00002318
	private void Reset()
	{
		this.startTouch = (this.swipeDelta = Vector2.zero);
		this.isDraging = false;
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00004140 File Offset: 0x00002340
	private GameObject ClosestEnemy()
	{
		return this.Enemies[0];
	}

	// Token: 0x0600005D RID: 93 RVA: 0x0000414E File Offset: 0x0000234E
	private IEnumerator EnemyDeath(GameObject Enemy)
	{
		yield return new WaitForSeconds(2f);
		Object.Destroy(Enemy);
		yield break;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00004160 File Offset: 0x00002360
	public void TapDetector()
	{
		if (this.Enemies.Count > 0 && this.ClosestEnemy().name == "SmallEnemyClone")
		{
			this.swipeTest.score++;
			this.ClosestEnemy().tag = "DeadZombie";
			if (this.audioSource)
			{
				this.audioSource.Play();
			}
			this.tap = true;
			this.ClosestEnemy().GetComponent<Animator>().SetBool("SmallEnemyDeath", true);
			this.ClosestEnemy().GetComponent<Animator>().SetBool("isHooking", false);
			this.ClosestEnemy().GetComponent<Animator>().speed = 2f;
			base.StartCoroutine(this.EnemyDeath(this.ClosestEnemy()));
			this.SmallEnemyDeathSound.Play();
		}
	}

	// Token: 0x040000BA RID: 186
	public GameObject EnemyCollider;

	// Token: 0x040000BB RID: 187
	public GameObject Player;

	// Token: 0x040000BC RID: 188
	public GameObject audioSourceObject;

	// Token: 0x040000BD RID: 189
	public GameObject audioSourceObjectSmallZombieDeath;

	// Token: 0x040000BE RID: 190
	public GameObject PunchSign;

	// Token: 0x040000BF RID: 191
	public GameObject SceneLoader;

	// Token: 0x040000C0 RID: 192
	public Transform InGameUi;

	// Token: 0x040000C1 RID: 193
	public GameOver gameOver;

	// Token: 0x040000C2 RID: 194
	private Vector2 startTouch;

	// Token: 0x040000C3 RID: 195
	private Vector2 swipeDelta;

	// Token: 0x040000C4 RID: 196
	private bool isDraging;

	// Token: 0x040000C5 RID: 197
	public bool tap;

	// Token: 0x040000C6 RID: 198
	public bool swipeUp;

	// Token: 0x040000C7 RID: 199
	public bool swipeDown;

	// Token: 0x040000C8 RID: 200
	public List<GameObject> Enemies = new List<GameObject>();

	// Token: 0x040000C9 RID: 201
	public AudioSource audioSource;

	// Token: 0x040000CA RID: 202
	public AudioSource SmallEnemyDeathSound;

	// Token: 0x040000CB RID: 203
	public RawImage Arrow;

	// Token: 0x040000CC RID: 204
	public Texture ArrowDownTexture;

	// Token: 0x040000CD RID: 205
	public Texture ArrowUpTexture;

	// Token: 0x040000CE RID: 206
	public float Distance;

	// Token: 0x040000CF RID: 207
	public SwipeTest swipeTest;
}
