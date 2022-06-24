using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameMusic : MonoBehaviour
{
    [SerializeField] private AudioSource gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        gameMusic.playOnAwake = true;
        gameMusic.loop = true;
        gameMusic.Play();
    }

    // Update is called once per frame
    void PlayMusic()
    {
        if (Pause.GameIsPaused)
        {
            gameMusic.Pause();   
        }
        if (!Pause.GameIsPaused && !gameMusic.isPlaying)
        {
            gameMusic.Play();
        }
    }

    private void Update()
    {
        if (gameMusic.isPlaying && Pause.GameIsPaused)
        {
            gameMusic.Pause();
        }
        if (!gameMusic.isPlaying && !Pause.GameIsPaused)
        {
            gameMusic.Play();
        }
    }

}
