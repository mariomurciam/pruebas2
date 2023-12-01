using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoPaddleFSM
{
    public State def;
    public State atc;
    private State now;
    private Paddle paddle;
    // Start is called before the first frame update
    public AutoPaddleFSM(Paddle paddle)
    {
        def = new OnDef(this, paddle);
        atc = new OnAtc(this, paddle);
        this.paddle = paddle;
        now = def;
        now.Enter();
    }

    // Update is called once per frame
    public void Update()
    {
        now.Update();
        //Debug.Log("!!!!!!" + ball.GetComponent<Rigidbody2D>().velocity.x);
    }

    public void OnNext(State next)
    {
        now.Exit();
        now = next;
        now.Enter();
    }
}
