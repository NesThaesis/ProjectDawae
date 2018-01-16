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
    public float CurrentVolume;

    public AudioSource BGMusic;
    public float MasterVolume;
    public AudioListener MV;
    

    public float Pause;



    void EndGame()
    {
        Pause = 0;
        GameObject.Find("UIOverlay").GetComponent<MenuesUI>().GameOver();
    }

    void Start()
    {
        Pause = 1;
        CurrentHP = MaxHP;
        Score = 0;
        CoinScore = 0;
        MasterVolume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
        AudioListener.volume = MasterVolume;
    }

    public void VolumeControll()
    {
        MasterVolume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
        AudioListener.volume = MasterVolume;
        CurrentVolume = AudioListener.volume;
    }

    public void MuteMaster()
    {
        AudioListener.volume = 0;
        CurrentVolume = AudioListener.volume;
    }


    void Update()
    {

        Time.timeScale = Pause;
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
