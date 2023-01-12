using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSpot : MonoBehaviour
{
    public float dmg;
  //  public float knockbackForce;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerStats.Instance.TakeDamage(dmg);
        }
        
    }
}



/*
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSpot : MonoBehaviour
{
    public float dmg;
    public Rigidbody2D enmeyRb;
    public float knockbackForce;


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.otherCollider.CompareTag("Player"))
        {
            PlayerStats.Instance.TakeDamage(dmg);
            Vector2 difference = (transform.position - col.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            enmeyRb.AddForce(force, ForceMode2D.Impulse); 
        }
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerStats.Instance.TakeDamage(dmg);
            Vector2 difference = (transform.position - col.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            enmeyRb.AddForce(force, ForceMode2D.Impulse);
        }
    }#1#
}
*/
