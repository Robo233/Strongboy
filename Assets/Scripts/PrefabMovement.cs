using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PrefabMovement : MonoBehaviour
{

    GameObject Target;
    int RandomNumberLeftSideSpawnPoint;
    GameObject[] Targets;
    float[] TargetPositions;
    int temp1, temp2;
    public float speedOfPrefab;
    GameObject SceneLoader;
    Speed speed;
   

    void Start()
    {
        Targets = GameObject.FindGameObjectsWithTag("Target");
        TargetPositions = new float[Targets.Length];
        SceneLoader = GameObject.Find("SceneLoader");
        speed = SceneLoader.GetComponent<Speed>();


    }

    void Update()
    {
        DistanceCalculatorBetweenPrefabAndTarget();

        Vector3 a = transform.position;
        Vector3 b = Target.transform.position;
        transform.position = Vector3.MoveTowards(a, b, speedOfPrefab);

        PrefabDestroyer();
        speedOfPrefab = speed.SpeedValue;

    }

    void DistanceCalculatorBetweenPrefabAndTarget()
    {
        for (int i = 0; i < Targets.Length; i++)
        {
           
            TargetPositions[i] = Math.Abs(Targets[i].transform.position.x - this.transform.position.x);

        }
        Target = Targets[SmallestNumberPosition(TargetPositions)];
    }

    void PrefabDestroyer()
    {
        if (this.transform.position.z < -25)
        {
            Destroy(gameObject);
        }
    }
   

    static public int SmallestNumberPosition(float[] nums)
    {
        
        int smallestPosition = 0;
        float smallesttNum = nums[0];
        int i = 0;
        for (i = 0; i <= nums.Length - 1; i++)
        {
            if (nums[i] < (float)smallesttNum)
            {
                smallesttNum = nums[i];
                smallestPosition = i;
            }
        }
        return smallestPosition;
    }

}
