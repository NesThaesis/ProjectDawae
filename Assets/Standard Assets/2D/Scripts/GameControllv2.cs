using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameControllv2 : MonoBehaviour
{
    public GameObject Player1;
    public Transform SpawnPoint_Player1;
    public float MaxHP;
    public float DMG;
    public float CurrentHP;
    public float CoinScore;
    public float Score;
    public Slider timeSlider;
    public float FxdDltTm;


    public float CurrentVolume;
    public AudioSource BGMusic;
    public Slider MasterVolume;
    public AudioListener MV;
    
    public float Pause;
    
    void EndGame()
    {
        Pause = 0;
        GameObject.Find("UIOverlay").GetComponent<MenuesUI>().GameOver();
    }

    private void Awake()
    {
        timeSlider = GameObject.Find("TimeControll").GetComponent<Slider>();
    }

    void Start()
    {
        RespawnPlayer1();
        Pause = 1;
        CurrentHP = MaxHP;
        Score = 0;
        CoinScore = 0;
        AudioListener.volume = MasterVolume.value;
    }

    public void HPDown()
    {
        GameObject.Find("hp" + CurrentHP).SetActive(false);
        CurrentHP--;
    }

    public void HPUp()
    {
       CurrentHP++;
       GameObject.Find("hp" + CurrentHP).SetActive(true);
    }
    
    public void RespawnPlayer1()
    {
       GameObject Knight = Instantiate(Player1, SpawnPoint_Player1);
        Knight.name = "Knight";
    }

    public void VolumeControll()
    {
        MasterVolume = GameObject.Find("VolumeSlider").GetComponent<Slider>();
        AudioListener.volume = MasterVolume.value;
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
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

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
