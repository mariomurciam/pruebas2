using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Patrol : Node
{
GhostBT ghostBT;
    UnityEngine.AI.NavMeshAgent agent;

    public Patrol(BTree btree) : base(btree)
    {
        ghostBT = bTree as GhostBT;
        agent = ghostBT.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        //Debug.Log(ghostBT.chompLayerMask);
        Transform target = (Transform)bTree.GetData("target");
        if (target != null) agent.destination = target.position;

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