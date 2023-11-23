using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AutoPaddleFSM : MonoBehaviour
{
    private State def;
    private State atc;
    private State now;
    public GameObject ball;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        def = new OnDef(this, ball.GetComponent<Rigidbody2D>());
        atc = new OnAtc(this, ball.GetComponent<Rigidbody2D>());
        gameManager = ball.GetComponentInParent<GameManager>();
        now = def;
        now.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        now.Update();
        //Debug.Log("!!!!!!" + ball.GetComponent<Rigidbody2D>().velocity.x);
    }

    public void OnDef()
    {
        now.Exit();
        now = def;
        now.Enter();
    }

    public void OnAtc()
    {
        now.Exit();
        now = atc;
        now.Enter();
    }
}
