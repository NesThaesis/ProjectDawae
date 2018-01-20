using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SvlHB : MonoBehaviour {
    public BoxCollider2D ShovelCollider;
    public AudioSource ShovelHit;

    // Use this for initialization
    private void Awake()
    {
        ShovelHit = GameObject.Find("Hit").GetComponent<AudioSource>();
        ShovelCollider = GetComponent<BoxCollider2D>();
    }

    void Start ()
    {
        
        ShovelCollider.enabled = false;
    }
	
	// Update is called once per frame
	public void Update ()
    {

    }

  
    public void OnTriggerEnter2D(Collider2D other)
    {
        
            if (GetComponentInParent<MyCharacterControl>().attacking == true && other.gameObject.tag == "Enemy")
            {
            other.gameObject.GetComponent<MonsterScript>().IsHit = true;
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3, 10), Random.Range(3, 5));
            GameObject.Find("GameController").GetComponent<GameControllv2>().Score += GameObject.Find("Knight").GetComponent<MyCharacterControl>().MonsterScore;
            ShovelHit.Play();
        }
            if (GetComponentInParent<MyCharacterControl>().DownAttacking == true && other.gameObject.tag == "Enemy")
            {
            other.gameObject.GetComponent<MonsterScript>().IsHit = true;
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(3, 10), Random.Range(3, 5));
            GameObject.Find("GameController").GetComponent<GameControllv2>().Score += GameObject.Find("Knight").GetComponent<MyCharacterControl>().MonsterScore;
            ShovelHit.Play();
        }

    }


}
