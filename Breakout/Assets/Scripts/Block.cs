using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int life;
    public int color;
    public SpriteRenderer spriteRenderer;
    public Sprite[] blue;
    public Sprite[] red;
    public Sprite[] orange;
    public Sprite[] purple;
    public Sprite[] green;
    private Sprite[,] sprites;
    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        score = Singleton<Score>.Instance;
        score.numBlocks++;
        if (score.lvl < 5)
        {
            life = UnityEngine.Random.Range(1, 3);
        }
        else
        {
            life = UnityEngine.Random.Range(1, 5);
        }

        //color = UnityEngine.Random.Range(0, 5);
        sprites = new Sprite[5, 4];
        Sprites(0, blue);
        Sprites(1, red);
        Sprites(2, orange);
        Sprites(3, purple);
        Sprites(4, green);
        //SwapSprite();
    }

    public void SetColor(int color)
    {
        this.color = color;
        SwapSprite();
    }

    void Sprites(int pos, Sprite[] ar)
    {
        for (int i = 0; i < ar.Length; i++)
        {
            this.sprites[pos, i] = ar[i];
        }
    }
    public void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            life--;
            if (life == 0)
            {
                //gameObject.SetActive(false);
                Destroy(gameObject);
            }
            SwapSprite();
        }



    }



    void Update()
    {
        SwapSprite();
        if (Input.GetKeyDown(KeyCode.C))
        {
            Destroy(gameObject);
        }
    }

    public void SwapSprite()
    {
        if (life > 0)
        {
            spriteRenderer.sprite = sprites[color, life - 1];
        }
    }

    void OnDestroy()
    {
        score.numBlocks--;
    }

}
