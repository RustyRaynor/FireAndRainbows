using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanagement : MonoBehaviour
{
    void Start()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Test");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void HowtoPlay()
    {
        SceneManager.LoadScene("HowtoPlay");
    }
}
