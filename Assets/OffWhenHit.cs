using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffWhenHit : MonoBehaviour {
 Collider2D m_Collider;

    void Start()
    {
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = GetComponent<Collider2D>();
        m_Collider.enabled = m_Collider.enabled;
    }

    

    private IEnumerator OnCollisionEnter2D(Collision2D other)
   
    {
        if (other.gameObject.tag == "Enemy")
        {
            //Toggle the Collider on and off when pressing the space bar
            m_Collider.enabled = !m_Collider.enabled;
            yield return new WaitForSeconds(3f);
            m_Collider.enabled = m_Collider.enabled;
            //Output to console whether the Collider is on or not
            Debug.Log("Collider.enabled = " + m_Collider.enabled);
        }

    }

}
