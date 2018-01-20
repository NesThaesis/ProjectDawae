using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    //public Rigidbody2D rb;
    public Vector3 target;
    public float Speed;
    private Vector3 currentPosition;

    // Use this for initialization
    void Start()
    {
        
        target = GameObject.Find("TargetPoint_Collectible").transform.position;
       
    }

    void OnBecameInvisible()
    {
        GameObject.Find("Spawner").GetComponent<Spawner>().CoinNumber--;
        enabled = false;
        Destroy(gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {

        // rb.velocity = new Vector2(speed, rb.velocity.y);
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
