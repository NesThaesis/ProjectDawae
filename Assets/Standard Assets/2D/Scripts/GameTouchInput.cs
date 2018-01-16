using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTouchInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (Input.GetTouch(0).deltaPosition.x > 0)
                {
                    Debug.Log("user is swiping to the right");
                }

                if (Input.GetTouch(0).deltaPosition.x < 0)
                {
                    Debug.Log("user is swiping to the left");
                }

                if (Input.GetTouch(0).deltaPosition.y < 0)
                {
                    Debug.Log("user is swiping to down");
                }

                if (Input.GetTouch(0).deltaPosition.y > 0)
                {
                        
                   Debug.Log("user is swiping to up");
                }
            }
        }


    }
}
