using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collision");
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }

    }
}
