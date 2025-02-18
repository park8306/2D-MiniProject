using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    string path = "D:\\UnityProject\\Sparta\\FlappyPlane_Project\\Builds\\PC\\";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.Debug.Log(path);
            Process.Start(path + "FlappyPlane.exe");

        }
    }
}
