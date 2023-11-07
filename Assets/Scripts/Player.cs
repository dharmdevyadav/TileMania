using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed =7f;
    [SerializeField] private float jumpSpeed = 15.5f;
    [SerializeField] private LayerMask JumpableGround;
    [SerializeField] AudioSource JumpSoundEffect;

    private float dirX;
    Rigidbody2D rb;
    CapsuleCollider2D cap;
    //public bool isJumping;
    private Animator anim;
    private SpriteRenderer sp;

    private enum movementState {idle,running,jumping,falling}
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cap = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        jumpingUpdate();
        jumpAndIdle();

    }
    /*void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }*/

    private void jumpingUpdate()
    {
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            JumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }
    }

    private void jumpAndIdle()
    {
        movementState state;
        if (dirX > 0f)
        {
            state = movementState.running;
            sp.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = movementState.running;
            sp.flipX = true;
        }
        else
        {
            state = movementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = movementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = movementState.falling;
        }
        anim.SetInteger("state", (int)state);

    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(cap.bounds.center, cap.bounds.size, 0f, Vector2.down,.1f, JumpableGround);
    }
}



