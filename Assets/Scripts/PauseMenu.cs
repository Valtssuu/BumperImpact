using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        bool GameIsPaused = CrossPlatformInputManager.GetButton("Pause");
        bool GameIsNotPaused = CrossPlatformInputManager.GetButton("Resume");
        bool GoToMenu = CrossPlatformInputManager.GetButton("Menu");


        if (GameIsPaused)
        {
            Pause();
        }
      
        if (GameIsNotPaused)
        {
            Resume();
        }
        
      
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

    }

    
}
