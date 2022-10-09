using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField] float gameTime=60;
    
    int attackerCount;
    Slider slider;
    public bool isTimeEnded = false;
    void Start()
    {
        
        slider = GetComponent<Slider>();
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = (Time.timeSinceLevelLoad / gameTime);
        
        if (Time.timeSinceLevelLoad >= gameTime)
        {
            isTimeEnded = true;

        }
    }
}
