using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] e;
    public GameObject a1;
    public float timer = 3f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            timer = 3f;
            GameObject i = Instantiate(e[UnityEngine.Random.Range(0, e.Length)], transform.position, Quaternion.identity);
            i.SetActive(true);
            i.transform.Rotate(-90, 0, 180);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
