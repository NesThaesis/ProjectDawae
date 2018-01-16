using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterControl : MonoBehaviour {
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool isVulnerable;
    public bool onGround;
    public float JumpHeight;
    public AudioSource JumpSound;
    public float Attack;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        isVulnerable = true;
    }
	  
    void Jump ()
    {
        if (onGround)
        {
            JumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }
    }
    

    // Update is called once per frame
    void Update () {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Input.GetMouseButtonDown(1))
        {

            GetComponent<MyCharacterControl>().Jump();
        }
              
    }
}
