using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour {

    public GameObject MenuUI;
    public GameObject SettingsUI;
    public GameObject SfxSounds;
    public float LastVolume;
    public bool sfxobject = true;

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "testscene");
    }

    public void Settings()
    {
        MenuUI.SetActive(false);
        SettingsUI.SetActive(true);
    }

    public void BackFromSettings()
    {
        MenuUI.SetActive(true);
        SettingsUI.SetActive(false);
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
            GameObject.Find("GameController").GetComponent<GameControllv2>().MasterVolume = GameObject.Find("VolumeSlider").GetComponent<Slider>();
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
