using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllv2 : MonoBehaviour {
 Collider2D m_Collider;
 
    public float MaxHP;
    public float DMG;
    public float CurrentHP;
    public float InvulnerableTime;


    void Start()
    {
        CurrentHP = MaxHP;
        //Fetch the GameObject's Collider (make sure it has a Collider component)
        m_Collider = GetComponent<Collider2D>();
        m_Collider.enabled = m_Collider.enabled;
    }

    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            CurrentHP = 0;
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(sceneName: "testscene");
        }
        if (CurrentHP <= 0)
        {
            SceneManager.LoadScene(sceneName:"gameover");
        }
    }

    private IEnumerator OnCollisionEnter2D(Collision2D other)
    {

        Debug.Log("VanHitbox? " + m_Collider.enabled);
        if (other.gameObject.tag == "Enemy")
        {
            //Toggle the Collider on and off when pressing the space bar
            m_Collider.enabled = !m_Collider.enabled;
            //Destroy(GetComponent<Transform>().GetChild(0).gameObject);
            Destroy(GameObject.Find("hp"+CurrentHP));
            CurrentHP--;
            yield return new WaitForSeconds(InvulnerableTime);
            m_Collider.enabled = true;
            //Output to console whether the Collider is on or not
            Debug.Log("VanHitbox?" + m_Collider.enabled);
        }

    }

}
