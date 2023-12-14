using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Lives lives;
    // Start is called before the first frame update
    void Start()
    {
        ball.gm = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapLives(bool more){
        lives.SwapLives(more);
    }

}
