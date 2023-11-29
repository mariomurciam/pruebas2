using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMS
{
    public State play { get; private set; }
    public State pause { get; private set; }
    public State menu { get; private set; }
    public State win { get; private set; }
    private State now;
    public GameObject objMenu;
    public GameManager gameManager;

    public FMS(GameManager gameManager, GameObject objMenu)
    {
        this.play = new OnPlay(this);
        pause = new OnPause(this);
        win = new OnWinner(this);
        menu = new OnMenu(this, objMenu);
        this.gameManager = gameManager;
        this.objMenu = objMenu;
        now = menu;
        now.Enter();
    }

    public void Update()
    {
        now.Update();
    }

    public void OnNext(State next)
    {
        now.Exit();
        now = next;
        now.Enter();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
