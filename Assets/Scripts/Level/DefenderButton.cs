using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender Defender;
    Text costText;
    void OnMouseDown()
    {
        var buuttons = FindObjectsOfType<DefenderButton>();
        foreach(var button in buuttons)
        {
            button.gameObject.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(28,28,28);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(Defender);
    }

    void Start()
    {
        costText = GetComponentInChildren<Text>();
        if (costText)
        {
            costText.text = Defender.GetStartCost().ToString();
        }
    }

}
