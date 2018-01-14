using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour {
    public float Countdown;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(Countdown > 0)
        {
            Countdown -= Time.deltaTime;
            Debug.Log("Time:" + Countdown);
        }

        if (Countdown <= 0)
        { 
            SceneManager.LoadScene(sceneName: "testscene");
        }
    }
}
