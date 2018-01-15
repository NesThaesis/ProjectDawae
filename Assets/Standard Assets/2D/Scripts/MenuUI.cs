using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{

    public void Quit()
    {
        Application.Quit();
    }
    public void Start()
    {
        SceneManager.LoadScene(sceneName: "testscene");
    }
}
