using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterControl : MonoBehaviour
{
    public Rigidbody2D rb;
   
    public Transform groundCheck;
    public float groundCheckRadius;

    public LayerMask whatIsGround;
    private bool isVulnerable;
    public bool onGround;
    
    public float JumpHeight;
    public float DownSpeed;

    public AudioSource JumpSound;
    public AudioSource SwordSlash;

    public float Attack;
    public float AttackStartTime;
    private float SlideTime;
    public float RushSpeed;
    public float RushStopSpeed;
    public float RushRange;
    
    public float RushStartTime;

    public Animator c_Animator;

    public bool Sliding;
    public bool attacking;
    public bool Rushing;
    public bool RushJump;
    public bool Rushattacking;
    public bool DownAttacking;
    public bool HoldingAttack;

    public float DelayBetweenAandR;
    private float Speed;
    public float ReturnSpeed;

    public Vector2 StartingPosition;
    public Vector2 Position;
    public Vector2 LastPosition;
    public Vector2 Velocity;
    public Vector2 RushTarget;



    public float MonsterScore;
    
    public int MBNumber;

    // Use this for initialization
    private void Awake()
    {
        SwordSlash = GameObject.Find("SwordSlash").GetComponent<AudioSource>();
        JumpSound = GameObject.Find("Jump").GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        StartingPosition = new Vector2(transform.position.x, transform.position.y);
    }

    void Start()
    {
        LastPosition = StartingPosition;
        Position = StartingPosition;
        AttackStartTime = Time.time;
        isVulnerable = true;
        Sliding = false;
        Rushattacking = false;
        DownAttacking = false;
        Rushing = false;
        attacking = false;
    }

    public void OnBecameInvisible()
    {
        Destroy(GameObject.Find("Knight"));
        GameObject.Find("GameController").GetComponent<GameControllv2>().HPDown();
        GameObject.Find("GameController").GetComponent<GameControllv2>().RespawnPlayer1();
    }
    

    public IEnumerator AttackFunction()
    {
        if (Sliding == false)
        {
            Debug.Log("pressed A");
            if (Time.time-AttackStartTime > 1)
            {
                GameObject.Find("ShovelHit").GetComponent<SvlHB>().ShovelCollider.enabled = true;
                attacking = true;
                SwordSlash.Play();
                AttackStartTime = Time.time;
                yield return new WaitForSeconds(0.5f);
                GameObject.Find("ShovelHit").GetComponent<SvlHB>().ShovelCollider.enabled = false;
            }
        }
    }

    public IEnumerator Attack2()
    {
        if (Sliding == false)
        {
            attacking = false;
            Debug.Log("lifted A");
            GameObject.Find("ShovelHit").GetComponent<SvlHB>().ShovelCollider.enabled = true;
            yield return new WaitForSeconds(0.2f);
            SwordSlash.Play();
            GameObject.Find("ShovelHit").GetComponent<SvlHB>().ShovelCollider.enabled = false;
            

        }
    }
    public void returnattack()
    {
        GameObject.Find("ShovelHit").GetComponent<SvlHB>().ShovelCollider.enabled = false;
        attacking = false;
    }

    public void Jump()
    {
        if (onGround && Rushattacking == true)
        {
            RushJump = true;
            rb.velocity = new Vector2(5, JumpHeight);
        }
        if (onGround && Rushattacking == false)
        {
            JumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            RushJump = false;
        }
        
    }

    public void DownAttack()
    {
        if (!onGround)
        {
            GameObject.Find("ShovelHit").GetComponent<SvlHB>().ShovelCollider.enabled = true;
            DownAttacking = true;
            rb.velocity = new Vector2(rb.velocity.x, DownSpeed);
        }
    }

    public void CoolSlide()
    {
        if (onGround && Sliding == false)
        {
            Sliding = true;
            GameObject.Find("Knight").GetComponent<CircleCollider2D>().enabled = false;
            BoxCollider2D KnightBox = GetComponent<BoxCollider2D>();
            KnightBox.size = new Vector2(0.7150041f, 0.8031601f);
            KnightBox.offset = new Vector2 (KnightBox.offset.x, -0.35f) ;
            BoxCollider2D HitBox = GameObject.Find("Hitbox").GetComponent<BoxCollider2D>();
            HitBox.size = new Vector2(1.275955f, 0.8038862f);
            HitBox.offset = new Vector2(HitBox.offset.x, -0.35f) ;
            SlideTime = Time.time;
            GameObject.Find("ShovelHit").GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void RushAttack()
    {
           //rb.velocity = new Vector2(RushRange, rb.velocity.y);
            RushTarget = new Vector2(rb.position.x + RushRange, rb.position.y);
            Rushattacking = true;
            RushStartTime = Time.time;
    }

    public void RushBack()
    {
        if (Rushattacking == true && Time.time - RushStartTime > 1)
        {
              if (Mathf.Round(rb.position.x) != Mathf.Round(StartingPosition.x))
                {

                    Velocity = (StartingPosition - rb.position) * RushStopSpeed;
                    rb.MovePosition(rb.position + Velocity * Time.fixedDeltaTime);

                }
                else
                {
                    Rushattacking = false;
                }
        }
        
    }

    // Update is called once per frame
    public void Update()
    {
        c_Animator.SetBool("attacking", attacking);
        c_Animator.SetBool("Rushattacking", Rushattacking);
        c_Animator.SetBool("Sliding", Sliding);
        c_Animator.SetBool("DownAttacking", DownAttacking);
        c_Animator.SetBool("HoldingAttack", HoldingAttack);

        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
        if (onGround && DownAttacking == true)
        {
            GameObject.Find("ShovelHit").GetComponent<SvlHB>().ShovelCollider.enabled = false;
            DownAttacking = false;
        }

        if (onGround && Sliding == true)
        {
            if (Time.time - SlideTime > 1)
            {
                Sliding = false;
                GameObject.Find("Knight").GetComponent<CircleCollider2D>().enabled = true;
                BoxCollider2D KnightBox = GetComponent<BoxCollider2D>();
                KnightBox.size = new Vector2(0.8031601f,0.7150041f);
                KnightBox.offset = new Vector2(KnightBox.offset.x, 0.3361688f);
                BoxCollider2D HitBox = GameObject.Find("Hitbox").GetComponent<BoxCollider2D>();
                HitBox.size = new Vector2(0.8038862f, 1.275955f);
                HitBox.offset = new Vector2(HitBox.offset.x, -0.09826756f);
                GameObject.Find("ShovelHit").GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        if (Rushattacking == true && RushJump == false && Time.time - RushStartTime < 1)
        {
            Velocity = (RushTarget - rb.position) * RushSpeed;
            rb.MovePosition(rb.position + Velocity * Time.fixedDeltaTime);
        }

        if (Rushattacking == true && Time.time - RushStartTime > 1 && onGround)
        {
            RushBack();
            //rb.velocity = new Vector2(-1, rb.velocity.y);
            RushJump = false;

        }
        
        /*if( Rushattacking == true && Time.time - RushStartTime > 1 && !onGround)
        {
            rb.velocity = new Vector2(-1, rb.velocity.y);
        }
        */

        
        Position = rb.position;
    }
}
       


