using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject linterna;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            linterna.SetActive(linterna.activeSelf == true ? false : true);
        }
    }
}
