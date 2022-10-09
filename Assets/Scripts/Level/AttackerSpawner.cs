//using System;
using System.Collections;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float timeUntilFirstAttack = 0;
    [SerializeField] GameObject[] Attackers;
    [SerializeField] bool SpawnEnemy = true;
    [Range(0.1f, 20)] [SerializeField] float minTimeBetweenSpawns;
    [Range(0.1f, 20)] [SerializeField] float maxTimeBetweenSpawns;
    [SerializeField] float timeDecreaser;
    [SerializeField] float difficulty;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
        difficulty = 1.1f- FindObjectOfType<GameOptions>().Difficulty;
        minTimeBetweenSpawns *= difficulty;
        maxTimeBetweenSpawns *= difficulty;
    }

    private IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(timeUntilFirstAttack);
        Debug.Log($"Spawn starts after {timeUntilFirstAttack}");
        StartCoroutine(SpawnAttacker());
    }

    private IEnumerator SpawnAttacker()
    {
        while (SpawnEnemy)
        {
            float timeToWait = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);

            yield return new WaitForSeconds(timeToWait);
            int num = Random.Range(0, Attackers.Length);
            var attacker = Instantiate(Attackers[num], transform.position, Quaternion.identity);
            attacker.transform.parent = transform;
            if (minTimeBetweenSpawns > 5)
                minTimeBetweenSpawns -= timeDecreaser;
            else if (maxTimeBetweenSpawns > 6)
                maxTimeBetweenSpawns -= timeDecreaser;
            else if (minTimeBetweenSpawns > 3)
                minTimeBetweenSpawns -= timeDecreaser;
            else if (maxTimeBetweenSpawns > 4)
                maxTimeBetweenSpawns -= timeDecreaser;
            else if (minTimeBetweenSpawns > 2)
                minTimeBetweenSpawns -= timeDecreaser;
            else if (maxTimeBetweenSpawns > 3)
                maxTimeBetweenSpawns -= timeDecreaser;
            else if (minTimeBetweenSpawns > 1)
                minTimeBetweenSpawns -= timeDecreaser;
            else if (maxTimeBetweenSpawns > 2)
                maxTimeBetweenSpawns -= timeDecreaser;

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
