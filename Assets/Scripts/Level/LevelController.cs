using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winGameText;
    [SerializeField] GameObject loseGameText;
    [SerializeField] float waitForLoadNextLevel;
    bool winHandled = false;
    SliderScript _timer;
    [SerializeField]
    SliderScript timer
    {
        get
        {
            if (!_timer)
                _timer = FindObjectOfType<SliderScript>();
            return _timer;
        }
    }
    private Lazy<AttackerSpawner[]> spawners=> new Lazy<AttackerSpawner[]>(() => FindObjectsOfType<AttackerSpawner>());
    bool spawnersStopped = false;


    // Update is called once per frame
    void Update()
    {
        HandleTimeEnded();
    }

    private void HandleTimeEnded()
    {
        if (timer && timer.isTimeEnded && !winHandled)
        {
            var attackerCount = spawners.Value.Sum(t => t.GetComponentsInChildren<Attacker>().Length);
            if (!spawnersStopped)
                spawners.Value.ToList().ForEach(t => t.StopAllCoroutines());
            if (attackerCount == 0)
            {
                winHandled = true;
                StartCoroutine(DisplayWin());
            }
        }
    }

    private IEnumerator DisplayWin()
    {
        Debug.Log("Win");
        Time.timeScale = 0;
        winGameText.SetActive(true);
        Debug.Log($"Wait: {waitForLoadNextLevel}");
        yield return new WaitForSeconds(1);
        Debug.Log("Load next level:");
        FindObjectOfType<LevelLoader>().LoadNextLevel();
        winHandled = false;
        winGameText.SetActive(false);
    }
    
    public void DisplayLose()
    {
        Time.timeScale = 0;
        loseGameText.SetActive(true);
    }
}
