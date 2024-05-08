using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public GameObject linterna;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void FixedUpdate()
    {
        linterna.transform.position = transform.position;
        linterna.transform.rotation = transform.rotation;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            linterna.SetActive(linterna.activeSelf == true ? false : true);
        }
    }
}
