using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ghost : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private GameObject target;
    private GameObject pacman;
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        pacman = GameObject.Find("Chomp");
        target = pacman;
    }

    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent != null) navMeshAgent.destination = target.transform.position;
    }
}
