using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCanvas : MonoBehaviour
{
    public void Retry()
    {
        FindObjectOfType<LevelLoader>().RestartLevel();
        FindObjectOfType<LoseCanvas>().gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        FindObjectOfType<LevelLoader>().LoadStartScene();
        FindObjectOfType<LoseCanvas>().gameObject.SetActive(false);
    }

}
