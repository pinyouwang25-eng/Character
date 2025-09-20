using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 11f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    private Rigidbody2D rd;
    private bool isGrounded; 
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float MoveInput = Input.GetAxis("Horizontal");
        rd.velocity = new Vector2(MoveInput * moveSpeed, rd.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded )
        {
            rd.velocity = new Vector2(rd.velocity.x, jumpForce);
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
}
