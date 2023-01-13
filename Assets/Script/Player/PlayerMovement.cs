using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public static bool isJumping;
    private bool isCrouch;
    private bool isGrounded; 

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;
    public static PlayerMovement instance;

    [SerializeField] private Transform center;
    [SerializeField] private float knockBackVelocity = 8f;
    [SerializeField] private bool knockBacked;
    [SerializeField] private float knockBackTime;
    public Rigidbody2D rb;
    public CapsuleCollider2D playerCollider;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    
    public AudioClip sound;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Il y a plus d'une instance de Player Movement dans la scène");
        }

        instance = this;
    }

    void Update()
    {  
        
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            AudioManager.instance.PlayClipAt(sound, transform.position);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }

        if (Input.GetButtonDown("Crouch") && isGrounded)
        {
            isCrouch = true;
            animator.SetBool("isCrouching", true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouch = false;
            animator.SetBool("isCrouching", false);
        }
        

        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FixedUpdate()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        if (!knockBacked)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0f, Time.deltaTime * 2), rb.velocity.y);
        }

        if(isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        } else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    public void KnockBack(Transform t)
    {
        Vector3 dir = center.position - t.position;
        knockBacked = true;
        rb.velocity = dir.normalized * knockBackVelocity;
        StartCoroutine(UnKnockBack());
    }

    private IEnumerator UnKnockBack()
    {
        yield return new WaitForSeconds(knockBackTime);
        knockBacked = false;
    }
}
