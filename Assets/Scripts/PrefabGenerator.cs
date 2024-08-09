using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    
    public static GameObject[] SpawnPoints;
    public static GameObject[] Prefabs;
    int RandomNumberPrefab;
    int RandomNumberSpawnPoints;
    float timer = 0.01f;
    float timeUntilNextPrefabIsSpawned = 0.1f;

    void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");
        Prefabs = GameObject.FindGameObjectsWithTag("Prefab");
        
    }

    void Update()
    {
        RandomNumberPrefab = Random.Range(0, Prefabs.Length);
        RandomNumberSpawnPoints = Random.Range(0, SpawnPoints.Length );

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = timeUntilNextPrefabIsSpawned;
            StartCoroutine(Generator());
        }

    }

    IEnumerator Generator()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject PrefabClone = GameObject.Instantiate(Prefabs[RandomNumberPrefab]);
        PrefabClone.transform.position = SpawnPoints[RandomNumberSpawnPoints].transform.position;
        PrefabClone.AddComponent<PrefabMovement>();
    }

}
