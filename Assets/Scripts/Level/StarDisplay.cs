using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 999;
    Text starText;

    void Start()
    {
        starText = GetComponent<Text>();
    }
    void  UpdateDisplay()
    {
        starText.text = stars.ToString("000");
    }
    public void AddStars(int amopunt)
    {
        stars += amopunt;
        UpdateDisplay();
    }

    public bool SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
            return true; 
        }
        return false;
    }
}
