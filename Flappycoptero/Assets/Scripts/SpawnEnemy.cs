using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] e;
    public GameObject a1;
    public GameObject star;
    public GameObject coin;
    private float timer = 0f;
    private float timerPoints = 1.5f;
    public float time = 3f;
    private int countStar = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = time;
            GameObject i = Instantiate(e[UnityEngine.Random.Range(0, e.Length)], transform.position, Quaternion.identity);
            i.SetActive(true);
            i.transform.position = new Vector3(i.transform.position.x, UnityEngine.Random.Range(-20f, -11.5f), i.transform.position.z);
            i.transform.Rotate(-90, 0, 180);
            i = Instantiate(a1, transform.position, Quaternion.identity);
            i.SetActive(true);
            i.transform.position = new Vector3(i.transform.position.x, UnityEngine.Random.Range(19.5f, 30.3f), i.transform.position.z);
            i.transform.Rotate(0, 90, 0);
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (timerPoints <= 0)
        {
            timerPoints = time;
            countStar++;
            GameObject i;
            if (countStar == 10)
            {
                i = Instantiate(star, transform.position, Quaternion.identity);
                countStar = 0;
            }
            else
            {
                i = Instantiate(coin, transform.position, Quaternion.identity);
            }

            i.SetActive(true);
            //i.transform.Rotate(-90, 0, 180);
            i.transform.position = new Vector3(i.transform.position.x, UnityEngine.Random.Range(2f, 30.3f), i.transform.position.z);
        }
        else
        {
            timerPoints -= Time.deltaTime;
        }

    }
}
