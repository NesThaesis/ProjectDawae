using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvlHB : MonoBehaviour {
    public Collider2D ShovelCollider;
    public AudioSource ShovelHit;
    public bool attacking;
    private float Speed;
    public float ReturnSpeed;
    public float DelayBetweenAandR;

    public float MonstersScore = 50;

    public AudioSource SwordSlash;
    public Animator ShovelAnimator;

    public int MBNumber;

    // Use this for initialization
    void Start ()
    {
        attacking = false;
        ShovelCollider = GetComponent<Collider2D>();
        ShovelCollider.enabled = false;
        ShovelAnimator = GameObject.Find("Lapat").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        ShovelAnimator.SetBool("attacking", attacking);

        if (Input.GetMouseButtonDown(0))
        {
            Invoke("AttackFunction", 0f);

        }
    }

    public void AttackFunction()
    {
        ShovelCollider.enabled = true;
        attacking = true;
        SwordSlash.Play();
        Invoke("returnattack", DelayBetweenAandR);
    }

    void returnattack()
    {
        ShovelCollider.enabled = false;
        Speed = ReturnSpeed;
        attacking = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            GameObject.Find("GameController").GetComponent<GameControllv2>().Score += 50;
            ShovelHit.Play();
        }

    }
}
