﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    Collider2D m_Collider;
    public float InvulnerableTime;
    private AudioSource gethitsound;

    // Use this for initialization
    void Start()
    {
        gethitsound = GetComponent<AudioSource>();
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = GetComponent<Collider2D>();
        m_Collider.enabled = m_Collider.enabled;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void colliderbackon()
    {
        m_Collider.enabled = true;
        Debug.Log("VanHitbox?" + m_Collider.enabled); //Output to console whether the Collider is on or not
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("VanHitbox? " + m_Collider.enabled);
        if (other.gameObject.tag == "Enemy" && m_Collider.enabled == true)
        {
            gethitsound.Play();
            m_Collider.enabled = false; //Toggle the Collider on and off when pressing the space bar
            Destroy(GameObject.Find("hp" + GameObject.Find("GameController").GetComponent<GameControllv2>().CurrentHP)); //Destroy(GetComponent<Transform>().GetChild(0).gameObject);
            GameObject.Find("GameController").GetComponent<GameControllv2>().CurrentHP--;

            Invoke("colliderbackon", InvulnerableTime);
           
        }
    }
}