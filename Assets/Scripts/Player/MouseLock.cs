using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MouseLock : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] public KeyCode pauseBtn = KeyCode.Escape;
    [SerializeField] private string currentScene;
    private bool usePauseBtn = false;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            if (Pause.GameIsPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                usePauseBtn = true;
            }
            if (!Pause.GameIsPaused || (Input.GetKeyDown(pauseBtn) && usePauseBtn))
            {
                Cursor.lockState = CursorLockMode.Locked;
                usePauseBtn = false;
            }
        }
    }


}
