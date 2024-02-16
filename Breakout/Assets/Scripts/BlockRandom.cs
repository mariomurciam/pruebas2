using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRandom : MonoBehaviour
{
    public GameObject block;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {

        //X -> -4.7 to 5.5f
        //Y -> 1 to 4
        float maxY = 1 + (gm.score.lvl * 0.2f);
        float maxX = 3 + (gm.score.lvl * 0.5f);
        if (maxY > 5)
        {
            maxY = 5;
        }
        if (maxX > 10)
        {
            maxX = 10;
        }
        for (int i = 0; i < maxY; i++)
        {
            float y = UnityEngine.Random.Range(1f, 4f);
            for (int z = 0; z < maxX; z++)
            {
                float x = UnityEngine.Random.Range(-4.7f, 4.7f);
                Instantiate(block, new Vector2(x, y), transform.rotation);
            }
        }
        gm.score.numBlocks--;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
