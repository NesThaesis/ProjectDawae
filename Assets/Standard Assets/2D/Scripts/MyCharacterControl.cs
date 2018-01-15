using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterControl : MonoBehaviour {
    public Rigidbody2D rb;
    public Transform groundCheck;
    public Transform startPosition;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool onGround;
    public float JumpHeight;
    private Collider2D collider;
    private bool isVulnerable;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        this.collider = GetComponent<Collider2D>();
        collider.enabled = true;
        isVulnerable = true;
    }
	    
    // Update is called once per frame
	void Update () {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Input.GetMouseButtonDown(0) && onGround )
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
        }
		
	}

    //void OnCollisionEnter2D(Collision2D other)
    //{
    //    Debug.Log("collision");
    //    if (this.isVulnerable && other.gameObject.tag == "Enemy")
    //   {
    //        this.isVulnerable = false;
    //        Debug.Log("HIT!!!!");
    //    }

    //}
}
