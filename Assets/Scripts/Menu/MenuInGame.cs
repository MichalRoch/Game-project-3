using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuInGame : MonoBehaviour
{
    public bool paused = false;

    public Canvas menuInGame;
    public Canvas options;
    public Canvas toMainMenu;

    public AudioMixerSnapshot gameSnapshot;
    public AudioMixerSnapshot pauseSnapshot;

    void Start()
    {
        menuInGame.enabled = false;
        options.enabled = false;
        toMainMenu.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Escape();
        }
    }

    private void Escape()
    {
        if (paused == true)
        {
            menuInGame.enabled = false ;
            options.enabled = false ;
            toMainMenu.enabled = false;
            Time.timeScale = 1;
            paused = false ;
            gameSnapshot.TransitionTo(0f);
        }
        else
        {
            menuInGame.enabled = true ;
            Time.timeScale = 0 ;
            paused = true ;
            pauseSnapshot.TransitionTo(0f);
        }
    }

    public void Resume()
    {
        Escape() ;
    }

    public void InGame_ToMainMenu()
    {
        menuInGame.enabled = false;
        toMainMenu.enabled = true;
    }
    
    public void InGame_Back()
    {
        menuInGame.enabled = true ;
        options .enabled = false ;
    }

    public void InGame_Yes()
    {
        Time.timeScale = 1 ;
        SceneManager.LoadScene(0);
    }

    public void INGame_No()
    {
        menuInGame.enabled = true ;
        toMainMenu.enabled = false ;
    }
    public void InGame_ToOptons() 
    {
        options.enabled = true ;
        menuInGame.enabled = false;
    }
}
