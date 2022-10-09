using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class DeathCollider : MonoBehaviour
{
    [SerializeField] Text displayText;
    [SerializeField] int maxHealth = 1000;
    float actHealth;

    void Start()
    {
        actHealth = maxHealth;
    }
    void Update()
    {
        displayText.text = actHealth.ToString();
        displayText.color = GetColor();
    }
    Color GetColor()
    {
        float r = 255;
        if(2*actHealth > maxHealth)
        {
            r = 255-(255 * (-maxHealth + (2 * actHealth)) / maxHealth); 
        }
        float g = 255;
        if (2 * actHealth< maxHealth)
        {

            g = 255 * (2 * actHealth) / maxHealth;

        }
        float b = 0;
        return new Color(r, g, b);
    }

    void OnDestroy()
    {
        FindObjectOfType<LevelController>()?.DisplayLose();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        actHealth--;
        if (actHealth <= 0)
            Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
