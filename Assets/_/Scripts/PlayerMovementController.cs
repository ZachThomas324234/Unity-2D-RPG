using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isFacingRight = true;
    private bool doubleJump;
    public Animator animator;

    //public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");
        groundLayer = LayerMask.GetMask("Ground"); // Change "Ground" to the name of your ground layer.
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);



        // Player movement
        float moveDirection = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs (moveDirection));

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        //animator.SetFloat("speed", Mathf.Abs(rb.velocity.x));












        // Player jump
        if (isGrounded)
        {
            doubleJump = true;
        }



        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if(!isGrounded && Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            doubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0.5f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }





        // Flip the character's direction
        if (moveDirection > 0 && !isFacingRight)
        {
            FlipCharacter();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            FlipCharacter();
        }

    }

    // Function to flip the character's direction
    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
 }
   


