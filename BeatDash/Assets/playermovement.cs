using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        Debug.Log("feetPos: " + feetPos);
        // if (feetPos == null)
        // {
        //     Debug.LogError("feetPos IS NULL! This is not just a visual bug.");
        // }
        // else
        // {
        //     Debug.Log("feetPos is successfully assigned.");
        // }
    }

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.35f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer = 0f;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.linearVelocity = Vector2.up * jumpForce;
                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            jumpTimer = 0f;
        }
    }
}
