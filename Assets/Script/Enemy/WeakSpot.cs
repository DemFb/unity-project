using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{

    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("DIE DIE DIE");
            // EnemyPatrol.instance.animator.SetTrigger("Die"); 
            Destroy(objectToDestroy);
        }
    }
}
