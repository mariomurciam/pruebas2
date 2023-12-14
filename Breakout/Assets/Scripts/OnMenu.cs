using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMenu : State
{
    private GameObject menu;
    private FMS fms;
    public OnMenu(FMS fms, GameObject menu)
    {
        this.fms = fms;
        this.menu = menu;
    }
    public void Enter()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }
    public void Update()
    {
        if (menu.activeSelf == false)
        {
            fms.OnNext(fms.pause);
        }
    }
    public void Exit()
    {
    }
}
