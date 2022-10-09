using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    void OnMouseDown()
    {
        SpawnDefender();
        Debug.Log("MouseDown");
    }

    public void SetSelectedDefender(Defender defend)
    {
        defender = defend;
    }
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        //return rawWorldPos;
        float newX = Mathf.Round(rawWorldPos.x);
        float newy = Mathf.Round(rawWorldPos.y);
        var result = new Vector2(newX, newy);
        Debug.Log($"original:{rawWorldPos} new:{result}");
        return result;
    }
    void SpawnDefender()
    {
        if (!defender)
            return;
        //var pos = Input.mousePosition;
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos = SnapToGrid(pos);
        pos.z = 0;
        foreach (var def in FindObjectsOfType<Defender>())
        {
            if (def?.transform.position == pos)
                return;
        }

        var stars = FindObjectOfType<StarDisplay>();
        if (!stars.SpendStars(defender.GetStartCost()))
            return;
        var newDefender = Instantiate(defender.gameObject,
            pos,
            Quaternion.identity);
        newDefender.transform.SetParent(transform);
    }
}
