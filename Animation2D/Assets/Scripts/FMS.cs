using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FMS
{
    public State idle { get; private set; }
    public State jump { get; private set; }
    public State fall { get; private set; }
    public State wallJump { get; private set; }
    private State now;
    public GameManager gm;

    public FMS(GameManager gameManager)
    {
        idle = new OnIdle(this);
        fall = new OnFall(this);
        jump = new OnJump(this);
        wallJump = new OnWallJump(this);
        this.gm = gameManager;
        now = idle;
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
