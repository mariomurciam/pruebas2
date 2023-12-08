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
    // Start is called before the first frame update
    void Start()
    {
        life = UnityEngine.Random.Range(1, 5);
        color = UnityEngine.Random.Range(0,5);
        sprites = new Sprite[5,4];
        Sprites(0,blue);
        Sprites(1,red);
        Sprites(2,orange);
        Sprites(3,purple);
        Sprites(4,green);
        SwapSprite();
    }

    void Sprites(int pos, Sprite[] ar){
        for(int i = 0; i<ar.Length;i++){
            this.sprites[pos,i] = ar[i];
        }
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

    void Update(){
        SwapSprite();
    }

    public void SwapSprite()
    {
        if(life > 0){
            spriteRenderer.sprite = sprites[color,life-1];
        }else{
            gameObject.SetActive(false);
        }
    }

}
