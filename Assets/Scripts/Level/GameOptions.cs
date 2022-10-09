using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOptions : MonoBehaviour
{

    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";

    //public static void SetMasterVolume(float volume)
    //{
    //    volume = Mathf.Clamp(volume, 0, 1);
    //    PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
    //}
    //public static void SetMasterDifficulty(float difficulty)
    //{
    //    difficulty = Mathf.Clamp(difficulty, 0, 1);
    //    PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
    //}

    public float Volume { get => PlayerPrefs.GetFloat(MASTER_VOLUME_KEY); set { PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, value); } }
    public float Difficulty { get => PlayerPrefs.GetFloat(DIFFICULTY_KEY); set { PlayerPrefs.SetFloat(DIFFICULTY_KEY, value); } }

    //[SerializeField] public float volume { get=>audioSource.Volume; set=>audioSource.Volume = value; }
    //[SerializeField] public float difficulty;
    [SerializeField] public readonly float DefaultVolume = 0.5f;
    [SerializeField] public readonly float DefaultDifficulty = 0.5f;

    MusicPlayer _audio = null;
    MusicPlayer audioSource
    {
        get
        {
            if (!_audio)
                _audio = FindObjectOfType<MusicPlayer>();
            return _audio;

        }
    }

    void Update()
    {
        if(audioSource)
        {
            audioSource.Volume = Volume;
        }
    }
    //// Start is called before the first frame update
    //void Start()
    //{
    //    if (FindObjectsOfType(GetType()).Length > 1)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        DontDestroyOnLoad(gameObject);

    //    }
    //}
}
