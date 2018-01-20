using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Htbx_collectible : MonoBehaviour {
    Collider2D c_Collider;
    public AudioSource CoinPickUp;
    // Use this for initialization
    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        c_Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("VanHitbox? " + c_Collider.enabled);
        if (other.gameObject.tag == "Collectible")
        {
            CoinPickUp.Play();
            GameObject.Find("GameController").GetComponent<GameControllv2>().CoinScore++;
            Destroy(other.gameObject);
        }
    }
}