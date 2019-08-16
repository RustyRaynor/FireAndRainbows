using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanagement : MonoBehaviour
{
    public Canvas menu;
    public Canvas Op;
    void Start()
    {
        
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Test");
    }
    public void Options()
    {
        menu.gameObject.SetActive(false);
        Op.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ReturntoMainMenu()
    {
        menu.gameObject.SetActive(true);
        Op.gameObject.SetActive(false);
    }
    public void Credits()
    {

    }
}
