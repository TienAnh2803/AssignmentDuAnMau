using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    public float climbSpeed = 4f;
    private Rigidbody2D rb;
    private bool isClimbing = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isClimbing=true;
            rb.gravityScale = 0f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isClimbing=false;
            rb.gravityScale = 2f;
        }
    }
    private void FixedUpdate()
    {
        if(isClimbing)
        {
            float ClimbingInput = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, ClimbingInput * climbSpeed);
        }
        
    }

}

