using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class GhostBT : BTree
{
    public List<Transform> patrolPositions;
    public LayerMask layerPlayer;
    public int currentTarget = 0;

    
    protected override Node SetupTree()
    {
        var rootNode = new Selector(this, new List<Node>() {
            new Sequence(this, new List<Node>() {
                new TargetIsOnRange(this),
                new GoToTarget(this),
            }),
            new Sequence(this, new List<Node>() {
                new GoToPoint(this),
                new Wait(this),
            }),
        });

        return rootNode;
    }
}
