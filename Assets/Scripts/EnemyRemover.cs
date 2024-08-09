using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    public GameObject Enemy;

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
    }
