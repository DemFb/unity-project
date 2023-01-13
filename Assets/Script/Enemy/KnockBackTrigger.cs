using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.collider.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.KnockBack(transform);
        }
    }
} 
