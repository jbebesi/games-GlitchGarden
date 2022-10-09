using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsCanvas : MonoBehaviour
{
    GameOptions gameOptions;
    [SerializeField] Slider volume;
    [SerializeField] Slider difficulty;

    void Start()
    {
        gameOptions = FindObjectOfType<GameOptions>();
        volume.value = gameOptions.Volume;
        difficulty.value = gameOptions.Difficulty;
    }

    void Update()
    {
        gameOptions.Volume = volume.value;
        Debug.Log($"Difficulty:{difficulty.value}");
        gameOptions.Difficulty = difficulty.value;
    }

    public void ResetDefaults()
    {
        volume.value = gameOptions.DefaultVolume;
        difficulty.value = gameOptions.DefaultDifficulty;
    }

    public void Back()
    {
        FindObjectOfType<LevelLoader>().LoadStartScene();
    }
}
