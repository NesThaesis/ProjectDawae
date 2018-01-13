using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterControl : MonoBehaviour {
    public Rigidbody2D rb;
    public Transform groundCheck;
    public Transform startPosition;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public float JumpHeight;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Input.GetMouseButtonDown(0) && onGround )
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }
		
	}
}
