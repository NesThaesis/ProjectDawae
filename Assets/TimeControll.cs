using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControll : MonoBehaviour {
    public Slider timeSlider;
	// Use this for initialization
	void Start () {
        timeSlider = GameObject.Find("TimeControll").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	public void Update () {
        Time.timeScale = timeSlider.value;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
