using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMS
{
    public State play { get; private set; }
    public State pause { get; private set; }
    public State win { get; private set; }
    private State now;
    public GameManager gameManager;

    public FMS(GameManager gameManager, Ball ball)
    {
        this.play = new OnPlay(this, ball);
        pause = new OnPause(this, ball);
        win = new OnWinner(this);
        this.gameManager = gameManager;
        now = pause;
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
