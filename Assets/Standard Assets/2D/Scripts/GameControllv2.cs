using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllv2 : MonoBehaviour
{
    public float MaxHP;
    public float DMG;
    public float CurrentHP;
    public float CoinScore;
    public float Score;
  
    [SerializeField]
    private GameObject gameOverUI;

    void EndGame()
    {
        gameOverUI.SetActive(true);
    }

    void Start()
    {
        CurrentHP = MaxHP;
        Score = 0;
        CoinScore = 0;
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
            //     SceneManager.LoadScene(sceneName:"gameover");
            Invoke("EndGame", 0f);
        }
    }
}
