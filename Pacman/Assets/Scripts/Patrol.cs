using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Patrol : Node
{
    GhostBT ghostBT;
    UnityEngine.AI.NavMeshAgent agent;

    int currentTarget = 0;

    public Patrol(BTree btree) : base(btree)
    {
        ghostBT = bTree as GhostBT;
        agent = ghostBT.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        //Debug.Log(ghostBT.chompLayerMask);


        Transform target = ghostBT.patrolPositions[currentTarget];
        if (target != null) agent.destination = target.position;
        if (Vector2.Distance(new Vector2(target.position.x, target.position.z), new Vector2(ghostBT.transform.position.x, ghostBT.transform.position.z)) < .5f)
        {
            currentTarget++;
            if (currentTarget >= ghostBT.patrolPositions.Count) currentTarget = 0;
        }

        state = NodeState.RUNNING;
        return state;
    }
}
/*
// Implementa la lógica de evaluación para el nodo compuesto aquí
            // Por ejemplo, puedes iterar sobre los hijos y evaluarlos individualmente
            foreach (Node child in children)
            {
                NodeState childState = child.Evaluate();
                if (childState != NodeState.SUCCESS)
                    return childState;
            }

            return NodeState.SUCCESS; // Si todos los hijos tienen éxito, este nodo también tiene éxito
*/