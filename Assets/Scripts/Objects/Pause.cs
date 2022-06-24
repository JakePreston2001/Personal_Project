using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public MouseLock mouseLock;
    public GameObject pauseMenu;

    private void Start()
    {
        Resume();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(mouseLock.pauseBtn)) 
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else if (!GameIsPaused)
            {
                PauseMenu();
            }
        }
    }
    

    public void Resume() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
   
    public void PauseMenu() 
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }

}
