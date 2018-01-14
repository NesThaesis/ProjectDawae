using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack2 : MonoBehaviour
{
    //public float scrollSpeed;
    //public float tileSizeZ;

    //private Vector2 startPosition;

    private Vector3 target;
    private Vector3 sourcePosition;
    private GameObject parent;
    private Collider2D collider;

    private float Speed;
    public float AtkRange;
    public float AtkSpeed;
    public float ReturnSpeed;
    public float DelayBetweenAandR;

    public int MBNumber;
    
    void Start()
    {
        target = transform.position;
        sourcePosition = transform.position;
        this.collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }

    void Atk()
    {
        target = new Vector3(transform.position.x + AtkRange, transform.position.y, transform.position.z);
        Speed = AtkSpeed;
        collider.enabled = true;
        Invoke("returnattack", DelayBetweenAandR);
    }

    void returnattack()
    {
        target = new Vector3(transform.position.x - AtkRange, transform.position.y, transform.position.z);
        collider.enabled = false;
        Speed = ReturnSpeed;
    }

    void Update()
    {
        sourcePosition = transform.position;
        if (Input.GetMouseButtonDown(MBNumber))
        {
            Invoke("Atk", 0f);
        }
        if (target != sourcePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        
    }
}