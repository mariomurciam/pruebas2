using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameManager gm;
    public Sprite sprite0;
    public Sprite sprite1;
    public SpriteRenderer sr1;
    public SpriteRenderer sr2;
    public SpriteRenderer sr3;
    public SpriteRenderer sr4;
    public int live = 3;
    // Start is called before the first frame update
    void Start()
    {
        SwapSprite();
    }

    public void SwapLives(bool more)
    {
        if (live < 4 && live > -1)
        {
            if (more == true)
            {
                live++;
            }
            else
            {
                live--;
            }
            SwapSprite();
            gm.score.lives = live;
        }
    }

    public void SwapSprite()
    {
        switch (live)
        {
            case 0:
                sr1.sprite = sprite0;
                sr2.sprite = sprite0;
                sr3.sprite = sprite0;
                sr4.sprite = sprite0;
                break;

            case 1:
                sr1.sprite = sprite1;
                sr2.sprite = sprite0;
                sr3.sprite = sprite0;
                sr4.sprite = sprite0;
                break;

            case 2:
                sr1.sprite = sprite1;
                sr2.sprite = sprite1;
                sr3.sprite = sprite0;
                sr4.sprite = sprite0;
                break;

            case 3:
                sr1.sprite = sprite1;
                sr2.sprite = sprite1;
                sr3.sprite = sprite1;
                sr4.sprite = sprite0;
                break;

            case 4:
                sr1.sprite = sprite1;
                sr2.sprite = sprite1;
                sr3.sprite = sprite1;
                sr4.sprite = sprite1;
                break;

            default:

                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
