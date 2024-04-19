using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParticleController : MonoBehaviour
{
    private bool end = false;
    private float timer = 2;
    private BoxCollider bc;
    private MeshRenderer meshRenderer;
    public ParticleSystem sistemaDeParticulas;
    // Start is called before the first frame update
    void Awake()
    {
        bc = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
        sistemaDeParticulas = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            sistemaDeParticulas.Play();
            bc.enabled = false;
            meshRenderer.enabled = false;
            end = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (end == true)
        {
            if (timer <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}
