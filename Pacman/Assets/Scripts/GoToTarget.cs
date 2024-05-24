using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class GoToTarget : Node
{
    GhostBT ghostBT;
    UnityEngine.AI.NavMeshAgent agent;

    public GoToTarget(BTree btree) : base(btree)
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