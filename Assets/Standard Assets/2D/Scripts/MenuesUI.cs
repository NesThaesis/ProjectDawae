using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuesUI : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject SettingsUI;
    public GameObject ScoreBoard;
    public GameObject GameOverUI;
    public GameObject SfxSounds;
    public float LastVolume;
    public bool sfxobject=true;

    public void Menu()
    {
        SceneManager.LoadScene(sceneName: "menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(sceneName: "testscene");
    }

    public void Settings()
    {
        PauseUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void BackFromSettings()
    {
        PauseUI.SetActive(true);
        SettingsUI.SetActive(false);
    }

    public void BacktoGame()
    {
        GameObject.Find("GameController").GetComponent<GameControllv2>().Pause = 1;
        PauseUI.SetActive(false);
        ScoreBoard.SetActive(true);
    }
    public void PauseGame()
    {
        GameObject.Find("GameController").GetComponent<GameControllv2>().Pause = 0;
        PauseUI.SetActive(true);
        ScoreBoard.SetActive(false);

    }
    public void GameOver()
    {
        ScoreBoard.SetActive(false);
        GameOverUI.SetActive(true);
    }
    public void MVONOFF()
    {

        if (GameObject.Find("GameController").GetComponent<GameControllv2>().CurrentVolume > 0.0)
        {
            GameObject.Find("GameController").GetComponent<GameControllv2>().MuteMaster();
            Debug.Log(LastVolume);
        }
        else
        {
            Debug.Log(LastVolume);
            GameObject.Find("GameController").GetComponent<GameControllv2>().MasterVolume = GameObject.Find("VolumeSlider").GetComponent<Slider>().value;
            GameObject.Find("GameController").GetComponent<GameControllv2>().VolumeControll();
        }
    }

    public void MusicOff()
    {

        if (GameObject.Find("BGMusic").GetComponent<AudioSource>().volume > 0.0)
        {
            GameObject.Find("BGMusic").GetComponent<AudioSource>().volume = 0;
            Debug.Log(LastVolume);
        }
        else
        {
            Debug.Log(LastVolume);
            GameObject.Find("BGMusic").GetComponent<AudioSource>().volume = GameObject.Find("MusicSlider").GetComponent<Slider>().value;
        }
    }

    public void SfxOff()
    {
        if (sfxobject == true)
        {
            SfxSounds.SetActive(false);
            sfxobject = false;
        }
        else
        {
            SfxSounds.SetActive(true);
            sfxobject = true;
        }

    
    }
    
}
