using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{

    private Transform playerSpawn;
    private Animator fadeSystem;
    public float dmg;

    private void Awake()
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerStats.Instance.TakeDamage(dmg);
            StartCoroutine(ReplacePlayer(collision));
            
        }
    }

    private IEnumerator ReplacePlayer(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = playerSpawn.position;
    }
}
