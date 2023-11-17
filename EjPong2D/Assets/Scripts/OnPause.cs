using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPause : State
{
    void Enter()
    {
        Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    void Pause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    void Exit() { }
}
