using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Wait : Node
{
    GhostBT ghostBT;
    public float tiempoInicial = 1f;
    private float tiempoActual;

    public Wait(BTree btree) : base(btree)
    {
        ghostBT = bTree as GhostBT;
        tiempoActual = tiempoInicial;
    }

    public override NodeState Evaluate()
    {
        state = NodeState.RUNNING;


        tiempoActual -= Time.deltaTime;
        if (tiempoActual < 0)
        {
            ghostBT.currentTarget++;
            if (ghostBT.currentTarget >= ghostBT.patrolPositions.Count) ghostBT.currentTarget = 0;
            tiempoActual = tiempoInicial;
            ghostBT.animator.SetFloat("MotionSpeed", 1.5f);
            state = NodeState.SUCCESS;
        }

        return state;
    }
}