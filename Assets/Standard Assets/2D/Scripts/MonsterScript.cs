using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    //public Rigidbody2D rb;
    public Vector3 target;
    public float Speed;
    private Vector3 currentPosition;
    public bool IsHit;
    // Use this for initialization
    void Start()
    {
        IsHit = false;
        // rb = GetComponent<Rigidbody2D>();
        target = GameObject.Find("TargetPoint").transform.position;
        // target = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
        GameObject.Find("Spawner").GetComponent<Spawner>().MonsterNumber -= 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);

        }
    }
}
