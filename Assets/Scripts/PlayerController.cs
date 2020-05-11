using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Ground Movement")]
    [Tooltip("Movement speed in tiles per second (1 tile = 1 meter")]
    [SerializeField]
    private float speed;

    [Header("Air Movement")]
    [Tooltip("The upward force applied when player jumps")]
    [Range(0f, 10f)]
    [SerializeField]
    private float jumpForce;

    private Rigidbody2D playerRigidbody;
    private bool isFacingRight = true;
    private bool isOnGround = true;
    new private Collider2D collider;
    private RaycastHit2D[] hits = new RaycastHit2D[16];
    private float groundDistanceCheck = 0.05f;
   
    private float horizontalInput = 0;
    private bool isJumpPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput += Input.GetAxis("Horizontal");
        isJumpPressed = isJumpPressed || Input.GetButtonDown("Jump");
    }

    private void ClearInputs()
    {
        horizontalInput = 0;
        isJumpPressed = false;
    }

    private void FixedUpdate()
    {
        float xVelocity = horizontalInput * speed;
        playerRigidbody.velocity = new Vector2(xVelocity, playerRigidbody.velocity.y);
        if ((isFacingRight && horizontalInput < 0) ||
            (!isFacingRight && horizontalInput > 0))
        {
            Flip();

        }

        // Jump Logic
        // Check for landing on the ground.
        int numHits = collider.Cast(Vector2.down, hits, groundDistanceCheck);
        isOnGround = numHits > 0;
        // Debugging.
        Vector2 rayStart = new Vector2(collider.bounds.center.x, collider.bounds.min.y);
        Vector2 RayDirection = Vector2.down * groundDistanceCheck;
        Debug.DrawRay(rayStart, RayDirection, Color.red, 1f);
        // Jump only if on the ground.

        if (isJumpPressed && isOnGround)
        {
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        // Update our animator system after updating the player's movement.
        //animator.SetFloat("xSpeed", Mathf.Abs(playerRigidbody.velocity.x));
       //animator.SetFloat("yVelocity", playerRigidbody.velocity.y);
       // animator.SetBool("isOnGround", isOnGround);

        ClearInputs();
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        //Vector3 scale = transform.localScale;
        //scale.x = isFacingRight ? 1 : -1;
        //transform.localScale = scale;
        transform.Rotate(0f, 180f, 0f);
    }
}
