using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public delegate void OnHealthChangedDelegate();
    public OnHealthChangedDelegate onHealthChangedCallback;

    public AudioClip hitSound;

    #region Sigleton
    private static PlayerStats instance;
    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<PlayerStats>();
            return instance;
        }
    }
    #endregion

    [SerializeField]
    private float health;
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private float maxTotalHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }
    public float MaxTotalHealth { get { return maxTotalHealth; } }

    public bool isInvisible = false;

    public float invicibilityFlashDelay = 0.15f;

    public float invicibilityTimeAfterHit = 3f;

    public SpriteRenderer playerGraphics;

    public void Heal(float health)
    {
        this.health += health;
        ClampHealth();
    }

    public void TakeDamage(float dmg)
    {
        if (!isInvisible)
        {

            AudioManager.instance.PlayClipAt(hitSound, transform.position);
            health -= dmg;
            ClampHealth();

            if (health <= 0)
            {
                Death();
                return;
            }
            PlayerMovement.instance.animator.SetTrigger("Hurt");
            isInvisible = true;
            StartCoroutine(InvicibilityFlash());
            StartCoroutine(HandleInvicibilityDelay());
        }
    }

    public void Death()
    {
        PlayerMovement.instance.enabled = false;
        PlayerMovement.instance.rb.bodyType = RigidbodyType2D.Static;
        PlayerMovement.instance.playerCollider.enabled = false;
        PlayerMovement.instance.animator.SetTrigger("Death");
        StartCoroutine(ReturnMenu());
    }

    public IEnumerator InvicibilityFlash()
    {
        while (isInvisible)
        {
            playerGraphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
            playerGraphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityFlashDelay);
        }
    }


    public IEnumerator HandleInvicibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvisible = false;
    }

    public void AddHealth()
    {
        if (maxHealth < maxTotalHealth)
        {
            maxHealth += 1;
            health = maxHealth;

            if (onHealthChangedCallback != null)
                onHealthChangedCallback.Invoke();
        }   
    }

    void ClampHealth()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        if (onHealthChangedCallback != null)
            onHealthChangedCallback.Invoke();
    }

    IEnumerator ReturnMenu()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
    }
}
