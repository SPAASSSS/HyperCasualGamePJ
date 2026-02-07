using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 12f;
    public Transform groundCheck;
    public float groundRadius = 0.12f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool jumpQueued;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump"))
            jumpQueued = true;
    }

    void FixedUpdate()
    {
        bool grounded = Physics2D.OverlapCircle(
            groundCheck.position, groundRadius, groundLayer
        );

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("YSpeed", rb.linearVelocity.y);

        if (jumpQueued && grounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }

        jumpQueued = false;
    }

    void OnDrawGizmosSelected()
    {
        if (!groundCheck) return;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

}
