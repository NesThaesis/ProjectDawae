using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTouchInput : MonoBehaviour
{
    public float Attack;
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDraging = false;
    private Vector2 startTouch, swipeDelta;

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Tap { get { return tap; } }


    // Use this for initialization
    void Start()
    {

        GameObject.Find("ShovelHit").GetComponent<SvlHB>();
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;

    }


    public void Update()
    {

        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                tap = true;
                startTouch = Input.touches[0].position;

            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;

                Reset();
            }
        }

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
        //Did we cross the deadzone?

        if (swipeDelta.magnitude > 150)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // left right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;

            }
            else
            {
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
            Reset();
        }

        //Controll

        if (SwipeLeft)
        { }
        if (SwipeRight)
        {
            if ((GameObject.Find("Knight").GetComponent<MyCharacterControl>().onGround))
            {
                GameObject.Find("Knight").GetComponent<MyCharacterControl>().RushAttack();
            }
        }
        if (SwipeUp)
        {
            GameObject.Find("Knight").GetComponent<MyCharacterControl>().Jump();
        }
        if (SwipeDown)
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
        if (Tap)
        {
            StartCoroutine(GameObject.Find("Knight").GetComponent<MyCharacterControl>().AttackFunction());
        }

        #region PCInput 
        if (Input.GetKeyDown("a"))
        {
            StartCoroutine(GameObject.Find("Knight").GetComponent<MyCharacterControl>().AttackFunction());

        }

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
        #endregion
    }
}