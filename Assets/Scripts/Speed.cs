using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{

    public float SpeedValue = 0.01f;
    public float SpeedIncrease = 0.0001f;
    
    void Update()
    {
        SpeedValue += SpeedIncrease;
    }
}
