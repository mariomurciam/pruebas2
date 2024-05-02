using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo : MonoBehaviour
{
    public MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * 0.02f;
        mr.material.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
        //mr.material.SetTextureOffset(name: "_BaseMap", value: new Vector2(x: offset, y: 0));
    }
}
