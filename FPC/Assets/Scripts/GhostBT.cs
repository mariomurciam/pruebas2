using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class GhostBT : BTree
{
    public List<Transform> patrolPositions;
    public LayerMask layerPlayer;
    public int currentTarget = 0;
    public Animator animator;


    protected override Node SetupTree()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("MotionSpeed", 1.5f);
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
