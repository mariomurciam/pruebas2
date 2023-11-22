using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMS : MonoBehaviour
{
    private State play;
    private State pause;
    private State menu;
    private State win;
    private State now;
    public GameObject objMenu;
    public GameManager gameManager;

    void Start()
    {
        play = new OnPlay(this);
        pause = new OnPause(this);
        win = new OnWinner(this);
        menu = new OnMenu(this, objMenu);
        gameManager = objMenu.GetComponentInParent<GameManager>();
        now = menu;
        now.Enter();
    }

    void Update()
    {
        now.Update();
    }

    public void OnPause()
    {
        now.Exit();
        now = pause;
        now.Enter();
        Debug.Log("OnPause");
    }

    public void OnPlay()
    {
        now.Exit();
        now = play;
        now.Enter();
        Debug.Log("OnPlay");
    }

    public void OnWinner()
    {
        now.Exit();
        now = win;
        now.Enter();
        Debug.Log("OnWinner");
    }

    public void OnMenu()
    {
        now.Exit();
        now = menu;
        now.Enter();
        Debug.Log("OnMenu");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
