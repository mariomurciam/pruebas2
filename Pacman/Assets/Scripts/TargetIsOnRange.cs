using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TargetIsOnRange : Node
{
    GhostBT ghostBT;
    UnityEngine.AI.NavMeshAgent agent;

    int currentTarget = 0;

    public TargetIsOnRange(BTree btree) : base(btree)
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
