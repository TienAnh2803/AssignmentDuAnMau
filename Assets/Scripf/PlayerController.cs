using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private Animator animator;
    private float moveInput;
    private bool isFacingRight = false;
    public float climbSpeed = 4f;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    [SerializeField] TrailRenderer tr;

    public CoinManager cm;

    private bool isClimbing = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        if (isDashing)
        {
            return;
        }
        {
            rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
        FlipSprite();



    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if (isClimbing)
        {
            float ClimbingInput = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, ClimbingInput * climbSpeed);
        }
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        animator.SetFloat("xVelocity", System.Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
    void FlipSprite()
    {
        if (isFacingRight && moveInput > 0f || !isFacingRight && moveInput < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        isGrounded = true;
        animator.SetBool("isJumping", !isGrounded);
        
        if (collision.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
            rb.gravityScale = 0f;
            animator.SetBool("IsClimbing", true);
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            cm.coinCount++;
            Destroy(collision.gameObject);
        }

    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {     
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            rb.gravityScale = 2f;
            animator.SetBool("IsClimbing",false);
        }
    }  
}
