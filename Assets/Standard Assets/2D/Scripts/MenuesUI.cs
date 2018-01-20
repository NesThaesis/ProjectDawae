using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[ExecuteInEditMode]
public class MenuesUI : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject SettingsUI;
    public GameObject ScoreBoard;
    public GameObject GameOverUI;
    public GameObject SfxSounds;
    public GameObject TouchInput;

    public GameObject Potion1;
    public GameObject Potion2;
    public GameObject Potion3;

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;

    public float LastVolume;
    public bool sfxobject=true;
    public bool doit = false;

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
        TouchInput.SetActive(true);
    }
    public void PauseGame()
    {
       
            GameObject.Find("GameController").GetComponent<GameControllv2>().Pause = 0;
             PauseUI.SetActive(true);
             ScoreBoard.SetActive(false);
             TouchInput.SetActive(false);
            
        
    }
    public void GameOver()
    {
        ScoreBoard.SetActive(false);
        GameOverUI.SetActive(true);
        TouchInput.SetActive(false);
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

    public void SpeedPotion()
    {
        GameObject.Find("Potion2").SetActive(false);
        GameObject.Find("GameController").GetComponent<GameControllv2>().Pause = 2;
        Invoke("NormalTime", 5);
    }

    public void NormalTime()
    {
     
        GameObject.Find("GameController").GetComponent<GameControllv2>().Pause = 1f;
    }

    public void HpPotion()
    {
        if (GameObject.Find("GameController").GetComponent<GameControllv2>().CurrentHP < 3)
        {
            GameObject.Find("GameController").GetComponent<GameControllv2>().CurrentHP++;
            float Currenthp = GameObject.Find("GameController").GetComponent<GameControllv2>().CurrentHP;
            hp3.SetActive(true);
            Potion1.SetActive(false);

        }
    }
    public IEnumerator Invincibility()
    {
        GameObject.Find("Barrier").SetActive(true);
        GameObject.Find("Hitbox").GetComponent<hitbox>().InvulnerableTime = 12;
        yield return new WaitForSeconds(12);
        GameObject.Find("Hitbox").GetComponent<hitbox>().InvulnerableTime = 2;
        GameObject.Find("Barrier").SetActive(false);
    }
}
