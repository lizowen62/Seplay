using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    public GameObject netMenuUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Option()
    {
        pauseMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void Title()
    {
        pauseMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void Connect()
    {
        mainMenuUI.SetActive(false);
        netMenuUI.SetActive(true);
    }
    
    public void Connectback()
    {
        netMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void reboot()
    {
        Data.difficulty += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void to_menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
