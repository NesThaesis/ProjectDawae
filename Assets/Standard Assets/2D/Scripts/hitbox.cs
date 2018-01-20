using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    Collider2D Hitbox;
    public float InvulnerableTime;
    public AudioSource gethitsound;
    public AudioSource CoinPickUp;
    public float LastHitTime;
    public float HitTime;

    // Use this for initialization
    private void Awake()
    {
        gethitsound = GameObject.Find("GetHit").GetComponent<AudioSource>();
        CoinPickUp = GameObject.Find("GetCoin").GetComponent<AudioSource>();
    }

    void Start()
    {
       Hitbox = GetComponent<Collider2D>();
       LastHitTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (GameObject.Find("Knight").GetComponent<MyCharacterControl>().Rushattacking == false)
        {
            HitTime = Time.time;
            Debug.Log("VanHitbox? " + Hitbox.enabled);
            if (other.gameObject.tag == "Enemy" && HitTime - LastHitTime > InvulnerableTime)
            {
                LastHitTime = Time.time;
                gethitsound.Play();
                GameObject.Find("GameController").GetComponent<GameControllv2>().HPDown();
            }
        }
        else
        {
            if (GetComponentInParent<MyCharacterControl>().Rushattacking == true && other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponent<MonsterScript>().IsHit = true;
                Rigidbody2D rbOther = other.GetComponent<Rigidbody2D>();
                rbOther.velocity = new Vector2(50, 10);
            }
        }
        if (other.gameObject.tag == "Collectible")
        {
            CoinPickUp.Play();
            GameObject.Find("GameController").GetComponent<GameControllv2>().CoinScore++;
            other.gameObject.GetComponent<Renderer>().enabled = false;
        }

    }
}