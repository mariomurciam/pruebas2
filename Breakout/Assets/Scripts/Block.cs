using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int life;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite sprite4;
    // Start is called before the first frame update
    void Start()
    {
        life = 4;
        SwapSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionExit2D()
    {
        life--;
        if (life == 0)
        {
            gameObject.SetActive(false);
        }
        SwapSprite();
    }

    public void SwapSprite()
    {
        switch (life)
        {
            case 1:
                spriteRenderer.sprite = sprite1;
                break;

            case 2:
                spriteRenderer.sprite = sprite2;
                break;

            case 3:
                spriteRenderer.sprite = sprite3;
                break;

            case 4:
                spriteRenderer.sprite = sprite4;
                break;

            default:
                spriteRenderer.sprite = null;
                break;

        }
    }

}
