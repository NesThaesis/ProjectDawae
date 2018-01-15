using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteScore : MonoBehaviour {
    private Text txt;
    private Text cointxt;
	// Use this for initialization
	void Start () {
        cointxt = GameObject.Find("CoinScore").GetComponent<Text>();
        cointxt.text = "" + GameObject.Find("GameController").GetComponent<GameControllv2>().CoinScore;
        txt = GameObject.Find("ScoreNumber").GetComponent<Text>();
        txt.text = "" + GameObject.Find("GameController").GetComponent<GameControllv2>().Score;
    }
	
	// Update is called once per frame
	void Update () {
        txt.text = "" + GameObject.Find("GameController").GetComponent<GameControllv2>().Score;
        cointxt.text = "" + GameObject.Find("GameController").GetComponent<GameControllv2>().CoinScore;
    }
}
