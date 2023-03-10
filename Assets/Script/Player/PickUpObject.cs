using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public AudioClip sound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            Inventory.instance.AddGems(1);
            GetComponent<Animator>().SetTrigger("GetItem");
            Destroy(gameObject, 0.5f);
        }
    }

}
