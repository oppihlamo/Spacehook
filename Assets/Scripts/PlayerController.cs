using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D playerRB;
    public float speed;
    public float input;
    public SpriteRenderer spriteRenderer;
    public float jumpForce;
    public float moveForce;
    public LayerMask groundLayer;
    private bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    void Update()
    {
        // player sprite flip based on input direction
        input = Input.GetAxisRaw("Horizontal");
        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }
        // player jump tied to button down and touching ground
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        // holds player upright and corrects sprite when landing
        if (isGrounded == true)
        {
            playerRB.rotation = 0;
            playerRB.freezeRotation = true;
        }

        else
        {
            playerRB.freezeRotation = false;
        }
        // player can only jump when grounded and button is pressed
        if (isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    void FixedUpdate()
    {
        // movement bound done with physics
        playerRB.AddForce(Vector2.right * input * moveForce, ForceMode2D.Impulse);
    }
}
