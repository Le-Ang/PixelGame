using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private LayerMask jumpableGround;
    private bool m_FacingRight = true;
    private float dirX = 0f;
    private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 14f;
    private bool moveLeft;
    private bool moveRight;

    private enum MovementState { idle, running, jumping, falling  }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (moveLeft)
        {
            dirX = -moveSpeed;
        }
        else if (moveRight)
        {
            dirX = moveSpeed;
        }
        else
        {
            dirX = 0f;
        }
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        UpdateAnimationState();
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }
    public void Jump()
    {
        if (IsGrounded())
        {
            GameObject.FindGameObjectWithTag("SoundManager").
                GetComponent<SoundManager>().PlaySoundEffect(MusicEffect.JUMP);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        if (dirX > 0f && !m_FacingRight)
        {
            Flip();
        }
        else if (dirX < 0f && m_FacingRight)
        {
            Flip();
        }
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
