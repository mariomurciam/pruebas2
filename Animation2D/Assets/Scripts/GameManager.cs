using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Mov mov;
    public FMS fms;
    // Start is called before the first frame update
    void Awake()
    {
        fms = new FMS(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
