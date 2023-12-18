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
        if (menu.GetComponent<Buttons>().end == true)
        {
            if(menu.GetComponent<Buttons>().online == false){
                fms.OnNext(fms.pause);
            }else{
                fms.pauseNet = new OnPauseNet(fms, fms.ball);
                fms.playNet = new OnPlayNet(fms);
                fms.OnNext(fms.pauseNet);
            }
           menu.SetActive(false); 
        }
    }
    public void Exit()
    {
    }
}
