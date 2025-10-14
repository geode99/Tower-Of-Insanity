using System;
using UnityEngine;

public class QuitButton : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
     
    }

    // Update is called once per frame
    public void Quit()
    {

        print("Quitting the game");
        Application.Quit();

    }
}


