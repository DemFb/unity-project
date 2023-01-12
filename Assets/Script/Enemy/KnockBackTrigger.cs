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
        /*if (col.otherCollider.CompareTag("Player"))
        {
            PlayerMovement.instance.KnockBack(transform);
            Debug.Log("TOUCHE GVFTYTDT");
        }*/
    }
   // public Rigidbody2D enmeyRb;
   // public float knockbackForce;
    
    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.otherCollider.CompareTag("Player"))
        {
            Vector2 difference = (transform.position - col.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            enmeyRb.AddForce(force, ForceMode2D.Impulse); 
        }
    }*/
}
