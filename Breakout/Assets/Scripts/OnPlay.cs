using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPlay : State
{
    private FMS fms;
    private Ball ball;
    public OnPlay(FMS fms, Ball ball)
    {
        this.fms = fms;
        this.ball = ball;
    }
    public void Enter() { }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fms.OnNext(fms.pause);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            fms.QuitGame();
        }
        if (ball.rb.velocity == Vector2.zero)
        {
            fms.OnNext(fms.start);
        }

        if (fms.gameManager.score.numBlocks == 0)
        {
            fms.gameManager.score.lvl++;
            fms.gameManager.score.numBlocks++;
            SceneManager.LoadScene("SampleScene");
        }
        if (fms.gameManager.lives.live == 0)
        {
            fms.QuitGame();
        }

    }
    public void Exit() { }
}
