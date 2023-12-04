using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int life;
    public SpriteRenderer spriteRenderer;
     public Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        life = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionExit2D(){
        life--;
        if(life == 0){
            gameObject.SetActive(false);
        }
    }

}
