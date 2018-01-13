using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack2 : MonoBehaviour
{
    //public float scrollSpeed;
    //public float tileSizeZ;

    //private Vector2 startPosition;

    public float speed = 0.5f;
    private Vector3 target;
    private Vector3 sourcePosition;

    private bool isShovelOut;
    private Collider2D collider;

    void Start()
    {
        target = transform.position;
        sourcePosition = transform.position;
        isShovelOut = false;
        this.collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }

    void returnattack()
    {
        target = Vector3.MoveTowards(sourcePosition, target, speed * Time.deltaTime);
        isShovelOut = false;
        collider.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            target = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
            collider.enabled = true;
            isShovelOut = true;
            Invoke("returnattack", 0.5f);

        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (isShovelOut && other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

    }
}