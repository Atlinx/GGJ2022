using System;
using System.Collections;
using System.Collections.Generic;
using Game.Input;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static PauseMenu _instance;

    public bool isPause = false;
    
    public GameObject pauseMenu;

    public void Pause()
    {
        isPause = !isPause;
        
        if (isPause)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }

    }
}
