using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
    [SerializeField] float addStars;
    StarDisplay starDisplay;
    float tempStars;
    int starsToAdd = 5;
    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        tempStars += addStars * Time.deltaTime;
        if (tempStars > starsToAdd)
        {
            starDisplay.AddStars(starsToAdd);
            tempStars -= starsToAdd;
        }
    }
}
