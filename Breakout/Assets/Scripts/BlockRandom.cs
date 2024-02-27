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
        if (maxY > 9)
        {
            maxY = 9;
        }
        if (maxX > 10)
        {
            maxX = 10;
        }
        ArrayList allY = new ArrayList();
        bool yIsNew = false;
        for (int i = 0; i < maxY; i++)
        {
            int y = 0;
            while (yIsNew == false)
            {
                bool repitY = false;
                y = UnityEngine.Random.Range(-2, ((int)System.Math.Round(maxY) - 1));
                foreach (int obj in allY)
                {
                    if (obj == y)
                    {
                        repitY = true;
                        //break;
                    }
                }
                if (repitY == false)
                {
                    yIsNew = true;
                }
            }
            yIsNew = false;
            bool xIsNew = false;
            allY.Add(y);
            int color = UnityEngine.Random.Range(0, 5);
            ArrayList allX = new ArrayList();
            for (int z = 0; z < maxX; z++)
            {
                int x = 0;
                while (xIsNew == false)
                {
                    bool repitX = false;
                    //x = UnityEngine.Random.Range(-5, 6) * 2;
                    x = UnityEngine.Random.Range(-(int)System.Math.Round(maxX / 2), (int)System.Math.Round(maxX / 2) + 1) * 2;
                    Debug.Log(x);
                    foreach (int obj in allX)
                    {
                        if (obj == x)
                        {
                            repitX = true;
                            //break;
                        }
                    }
                    if (repitX == false)
                    {
                        xIsNew = true;
                    }
                }
                xIsNew = false;
                allX.Add(x);
                GameObject blockIns = Instantiate(block, new Vector2(x, y), transform.rotation);
                blockIns.GetComponent<Block>().SetColor(color);
            }
        }
        gm.score.numBlocks--;
    }
}
