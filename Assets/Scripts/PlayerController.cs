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
    public Animator walk;
    private bool playerControls = true;
    public Collider2D endDoor;
    CharacterController controller;
    public bool respawnAvailable = true;


    void Start()
    {
        walk = GetComponent<Animator>();
    }
    void Update()
    {   //removes player control in tandem with method checking if level end door has been touched
        if (!playerControls)
        {
            controller.enabled = false;
        }

        if (respawnAvailable)
        {   // respawn on keypress, with spamfilter
            if (Input.GetKeyDown(KeyCode.R))
            {
                RespawnController.instance2.RespawnToCheckpoint();
                respawnAvailable = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            respawnAvailable = true;
        }
        // exit button
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

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
        if (isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
            UpdateAnimation();
    }
        void UpdateAnimation()
        {   // booleans for toggling walking animation
            if (isGrounded && (input != 0))
            {
                walk.SetBool("isWalking", true);
            }
            else
            {
            walk.SetBool("isWalking", false);
            }
        }

    void OnTriggerEnter2D(Collider2D end)
    {   //when player hits level end door, turn off player controls
        PlayerController player = end.GetComponent<PlayerController>();
        if (player != null)
        {
            playerControls = false;
        }
    }
    void FixedUpdate()
    {
        // movement bound done with physics
        playerRB.AddForce(Vector2.right * input * moveForce, ForceMode2D.Impulse);
    }
}
