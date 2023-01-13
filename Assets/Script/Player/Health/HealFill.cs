using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealFill : MonoBehaviour
{
    public float heal;
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // AudioManager.instance.PlayClipAt(sound, transform.position);
            PlayerStats.Instance.Heal(heal);
            GetComponent<Animator>().SetTrigger("GetItem"); 
            Destroy(gameObject, 0.5f);
        }
    }
}
