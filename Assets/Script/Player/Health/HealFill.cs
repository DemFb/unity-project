using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFill : MonoBehaviour
{
    public float heal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerStats.Instance.Heal(heal);
            Destroy(gameObject);
        }
    }
}
