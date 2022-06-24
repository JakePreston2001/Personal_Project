using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceInteractController : MonoBehaviour
{
    [SerializeField] public new AudioSource audio;
    public bool playing;
    public void playMessgage() 
    {
        if (Pause.GameIsPaused)
        {
            audio.Pause();
        }
        else
        {
            audio.Play();
        }
    }
}
