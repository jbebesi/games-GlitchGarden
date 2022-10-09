using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public float Volume { get => audioSource.volume; set => audioSource.volume = value; }
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        var options = GetComponent<GameOptions>();
        if (options)
            audioSource.volume = options.Volume;
    }
}
