using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public AudioClip killSound;

    public GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            AudioManager.instance.PlayClipAt(killSound, transform.position);
            Debug.Log("DIE DIE DIE");
            // EnemyPatrol.instance.animator.SetTrigger("Die"); 
            Destroy(objectToDestroy);
        }
    }
}
