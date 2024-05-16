using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class GhostBT : BTree
{
    protected override Node SetupTree(){
        return new Patrol(this);
    }
}
