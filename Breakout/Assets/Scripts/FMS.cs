using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FMS
{
    public State play { get; private set; }
    public State pause { get; private set; }
    public State win { get; private set; }
    public State start { get; private set; }
    private State now;
    public GameManager gameManager;

    public FMS(GameManager gameManager, Ball ball)
    {
        this.play = new OnPlay(this, ball);
        this.pause = new OnPause(this, ball);
        this.win = new OnWinner(this);
        this.start = new OnStart(this, ball);
        this.gameManager = gameManager;
        now = start;
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
