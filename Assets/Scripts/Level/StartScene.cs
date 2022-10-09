using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour
{

    public void LoadLevel1()
    {
        FindObjectOfType<LevelLoader>().LoadLevel1();
    }

    public void LoadOptions()
    {
        FindObjectOfType<LevelLoader>().LoadOptions();
    }
}
