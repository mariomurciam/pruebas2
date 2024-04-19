using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObj : MonoBehaviour
{
    public bool helice;
    public int rotate;
    void FixedUpdate()
    {
        if (helice)
        {
            transform.Rotate(0, 0, rotate * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, rotate * Time.deltaTime, 0);
        }

    }
}
