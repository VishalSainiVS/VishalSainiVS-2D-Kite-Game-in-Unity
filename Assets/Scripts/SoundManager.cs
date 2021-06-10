using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public bool musicPause  ;

    public AudioSource _audioSource;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            musicPause = true;
            AudioListener.pause = false;
        }
        else if (PlayerPrefs.GetInt("Sound") == 1)
        {
            musicPause = false;
            AudioListener.pause = true;
        }
    }
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("ERROR::SoundManager:: Audio Source not found");
        }

       

       
    }
    private void Update()
    {
        if (musicPause)
        {
            AudioListener.pause = false;
        }
        else
            AudioListener.pause = true;
    }
}
