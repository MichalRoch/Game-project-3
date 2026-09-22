using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Canvas main;
    public Canvas options;
    public Canvas quit;

    private void Start()
    {
        main.enabled = true;
        options.enabled = false;
        quit.enabled = false;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsButton()
    {
        main.enabled = false;
        options.enabled = true;
    }

    public void QuitButton()
    {
        main.enabled = false;
        quit.enabled = true;
    }

    public void BackButton()
    {
        options.enabled = false;
        main.enabled = true;
    }

    public void YesButton()
    {
        Application.Quit();
    }

    public void NoButton()
    {
        main.enabled = true;
        quit.enabled = false;
    }
}
