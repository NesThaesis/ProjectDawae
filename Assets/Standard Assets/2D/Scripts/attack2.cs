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
    private Vector3 sourceTarget;
    private Vector3 currentPosition;
    private Collider2D collider;

    private float Speed;
    public float AtkRange;
    public float AtkSpeed;
    public float ReturnSpeed;
    public float DelayBetweenAandR;
    public float MonstersScore=50;
    

    public int MBNumber;
    
    void Start()
    {

        target = transform.position;
        sourcePosition = transform.position;
        currentPosition = transform.position;
        sourceTarget = new Vector3(sourcePosition.x, transform.position.y, transform.position.z);
        this.collider = GetComponent<Collider2D>();
        collider.enabled = false;
    }

    void Atk()
    {
        sourcePosition = currentPosition;
        target = new Vector3(transform.position.x + AtkRange, transform.position.y, transform.position.z);
        Speed = AtkSpeed;
        collider.enabled = true;
        Invoke("returnattack", DelayBetweenAandR);
    }

    void returnattack()
    {
        target = sourcePosition;
        collider.enabled = false;
        Speed = ReturnSpeed;
    }

    void Update()
    {
        currentPosition = transform.position;
        if (currentPosition.x == sourcePosition.x)
        {
            if (Input.GetMouseButtonDown(MBNumber) && GameObject.Find("Knight").GetComponent<MyCharacterControl>().onGround)
            {
                Debug.Log("OnGround?:" + GameObject.Find("Knight").GetComponent<MyCharacterControl>().onGround);
                Invoke("Atk", 0f);
            }
        }
        if (currentPosition.x != target.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Speed * Time.deltaTime);
            Debug.Log("Target:" + target);
            Debug.Log("source:" + sourcePosition);
        }
               
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            GameObject.Find("GameController").GetComponent<GameControllv2>().Score += 50;
        }
        
    }
}