using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class GoToPoint : Node
{
    GhostBT ghostBT;
    UnityEngine.AI.NavMeshAgent agent;

    

    public GoToPoint(BTree btree) : base(btree)
    {
        ghostBT = bTree as GhostBT;
        agent = ghostBT.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        state = NodeState.RUNNING;


        Transform target = ghostBT.patrolPositions[ghostBT.currentTarget];
        if (target != null) agent.destination = target.position;
        if (Vector2.Distance(new Vector2(target.position.x, target.position.z), new Vector2(ghostBT.transform.position.x, ghostBT.transform.position.z)) < .5f)
        {
            state = NodeState.SUCCESS;
        }

        
        return state;
    }
}