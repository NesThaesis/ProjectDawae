using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour {

    public void Quit()
    {
        Application.Quit();
    }
    public void Retry()
    {
        SceneManager.LoadScene(sceneName: "testscene");
    }
}
