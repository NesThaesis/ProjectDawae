using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTouchInput : MonoBehaviour
{
    private Vector2 touchOrigin = -Vector2.one;
    public Vector2 touchEnd;
    public Touch myTouch;
    public bool MouseButtonOnce;
    public float Attack;

    
    // Use this for initialization
    void Start()
    {
        
        GameObject.Find("ShovelHit").GetComponent<SvlHB>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            StartCoroutine(GameObject.Find("Knight").GetComponent<MyCharacterControl>().AttackFunction());

        }
        if (Input.GetKeyUp("a"))
        {
            StartCoroutine(
            GameObject.Find("Knight").GetComponent<MyCharacterControl>().Attack2());
            
        }

        /* if (Input.GetKeyDown("a"))
         {
             StartCoroutine(GameObject.Find("Knight").GetComponent<MyCharacterControl>().AttackFunction());

         }
         */

        if (Input.GetKeyDown("w"))
        {
            GameObject.Find("Knight").GetComponent<MyCharacterControl>().Jump();
        }

        if (Input.GetKeyDown("s"))
        {
            if (GameObject.Find("Knight").GetComponent<MyCharacterControl>().onGround == false)
            {
                GameObject.Find("Knight").GetComponent<MyCharacterControl>().DownAttack();
            }
            else
            {
                GameObject.Find("Knight").GetComponent<MyCharacterControl>().CoolSlide();
            }
        }
        if (Input.GetKeyDown("d"))
        {
            if ((GameObject.Find("Knight").GetComponent<MyCharacterControl>().onGround))
            {
                GameObject.Find("Knight").GetComponent<MyCharacterControl>().RushAttack();
            }
        }

        int horizontal = 0;
        int vertical = 0;


        /*  for (int i = 0; i < Input.touchCount; ++i)
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
                      GameObject.Find("Knight").GetComponent<MyCharacterControl>().Jump();     
                     Debug.Log("user is swiping to up");
                  }
              }
          }


      }
      */


        /* if (Input.touchCount > 0)
         {
             myTouch = Input.touches[0];
             if (myTouch.phase == TouchPhase.Began)
             {
                 touchOrigin = myTouch.position;
             }
             else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >= 0)
             {
                 //Set touchEnd to equal the position of this touch
                 touchEnd = myTouch.position;

                 //Calculate the difference between the beginning and end of the touch on the x axis.
                 float x = touchEnd.x - touchOrigin.x;

                 //Calculate the difference between the beginning and end of the touch on the y axis.
                 float y = touchEnd.y - touchOrigin.y;

                 //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                 touchOrigin.x = -1;

                 //Check if the difference along the x axis is greater than the difference along the y axis.
                 if (Mathf.Abs(x) > Mathf.Abs(y))
                 {
                     //If x is greater than zero, set horizontal to 1, otherwise set it to -1
                     horizontal = x > 0 ? 1 : -1;
                 }
                 else
                 {        //If y is greater than zero, set horizontal to 1, otherwise set it to -1
                     vertical = y > 0 ? 1 : -1;
                 }
             }


             if ( myTouch.phase == TouchPhase.Ended)
             {
                 if (touchEnd.y > touchOrigin.y && touchOrigin.x + touchEnd.x < touchOrigin.y + touchEnd.y)
                 {
                     GameObject.Find("Knight").GetComponent<MyCharacterControl>().Jump();
                 }

                 if (touchEnd.y < touchOrigin.y && touchOrigin.x+touchEnd.x < touchOrigin.y+touchEnd.y)
                 {
                     if (GameObject.Find("Knight").GetComponent<MyCharacterControl>().onGround == false)
                     {
                         GameObject.Find("Knight").GetComponent<MyCharacterControl>().DownAttack();
                     }
                     else
                     {
                         GameObject.Find("Knight").GetComponent<MyCharacterControl>().CoolSlide();
                     }
                 }

                 if(touchEnd.x < touchOrigin.x && touchOrigin.x + touchEnd.x > touchOrigin.y + touchEnd.y)
                 {
                     GameObject.Find("Knight").GetComponent<MyCharacterControl>().RushAttack();
                 }

             }


         }
         */
    }
}
