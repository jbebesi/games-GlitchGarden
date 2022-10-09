using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float waitForStartScene=3;

    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectsOfType(GetType()).Length>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            StartCoroutine(LoadStartSceneWithDelay());
        }
    }

    internal void RestartLevel()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(scene);
        SceneManager.LoadScene(scene.buildIndex);
        
    }

    public void LoadEndGameScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public IEnumerator LoadStartSceneWithDelay()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(waitForStartScene);
        SceneManager.LoadScene("StartScene");
    }

    public void LoadLevel1()
    {
        Time.timeScale = 1;
        Debug.Log("LoadLevel1");
        SceneManager.LoadScene("Level1");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    internal void LoadNextLevel()
    {
        Time.timeScale = 1;
        Debug.Log("Load...");
        var actLevel = SceneManager.GetActiveScene();
        Debug.Log($"Act level:{actLevel}");
        Debug.Log($"Load next level:{actLevel.buildIndex} ");
        SceneManager.LoadScene(actLevel.buildIndex + 1);
    }
}
