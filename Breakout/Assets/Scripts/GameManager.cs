using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text lvl;
    public Ball ball;
    public Paddle paddle;
    public Lives lives;
    public FMS fms;
    public Score score;
    // Start is called before the first frame update
    void Awake()
    {
        score = Singleton<Score>.Instance;
        if (score.lives == 0)
        {
            score.lives = lives.live;
        }
        else
        {
            lives.live = score.lives;
        }
        lives.SwapSprite();
        lvl.text += score.lvl;

        fms = new FMS(this, ball);
        ball.gm = this;
    }

    // Update is called once per frame
    void Update()
    {
        fms.Update();
    }

    public void Reset()
    {
        ball.Reset();
        paddle.Reset();
        lives.SwapLives(false);

    }

}
