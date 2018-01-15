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
        Speed = Random.Range(5, 10);
        target = GameObject.Find("TargetPoint_Collectible").transform.position;
       
    }

    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
        GameObject.Find("Spawner").GetComponent<Spawner>().CoinNumber -= 1;
    }

    // Update is called once per frame
    void Update()
    {

        // rb.velocity = new Vector2(speed, rb.velocity.y);
        transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
