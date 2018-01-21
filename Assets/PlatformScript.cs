using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    //public Rigidbody2D rb;
    public Vector3 target;
    public float Speed;
    private Vector3 currentPosition;
    

    // Use this for initialization
    void Start()
    {
        // rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("TargetPoint_Platform").transform.position;
        // target = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
        GameObject.Find("Spawner").GetComponent<Spawner>().PlatformNumber -= 1;

    }

    // Update is called once per frame
    void Update()
    {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
    }
}
