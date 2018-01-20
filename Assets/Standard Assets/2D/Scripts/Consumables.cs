using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour {
   
	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpeedPotion()
    {
        Time.timeScale = 1.5f;
    }

    public void HpPotion()
    {
        GameObject.Find("GameController").GetComponent<GameControllv2>().HPUp();
    }

    public IEnumerator Invincibility()
    {
        GameObject.Find("Barrier").SetActive(true);
        GameObject.Find("Hitbox").GetComponent<hitbox>().InvulnerableTime = 12;
        yield return new WaitForSeconds(12);
        GameObject.Find("Hitbox").GetComponent<hitbox>().InvulnerableTime = 2;
        GameObject.Find("Barrier").SetActive(false);
    }

    public void RunInvincibility()
    {
        StartCoroutine("Invincibility");
    }
}
