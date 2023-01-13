using UnityEngine;

public class HurtSpot : MonoBehaviour
{
    public float dmg;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerStats.Instance.TakeDamage(dmg);
            PlayerMovement.instance.animator.SetTrigger("Hurt");
        }
        
    }
}

