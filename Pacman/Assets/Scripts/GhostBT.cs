using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class GhostBT : BTree
{
    public List<Transform> patrolPositions;

    protected override Node SetupTree()
    {
        var rootNode = new Selector(this, new List<Node>() {
            new Sequence(this, new List<Node>() {
                new TargetIsOnRange(this),
                //new GoToTarget(this),
            }),
            new Patrol(this),
        });

        return rootNode;
    }
}
