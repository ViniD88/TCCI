using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public Canvas menu;
    public bool isPaused = false;

    private void Start()
    {
        menu.enabled = false;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = !menu.enabled;
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;

    }

    public void Resume()
    {
        Time.timeScale = 1;
        isPaused = false;

    }

}