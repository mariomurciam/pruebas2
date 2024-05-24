using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class TargetIsOnRange : Node
{
    GhostBT ghostBT;
    UnityEngine.AI.NavMeshAgent agent;

    public TargetIsOnRange(BTree btree) : base(btree)
    {
        ghostBT = bTree as GhostBT;
        agent = ghostBT.transform.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public override NodeState Evaluate()
    {
        state = NodeState.FAILURE;
        //Debug.Log(ghostBT.chompLayerMask);
        float radio = 5f;
        Vector3 posicionCentro = ghostBT.transform.position;

        // Encontrar todos los colliders dentro del radio especificado
        Collider[] colliders = Physics.OverlapSphere(posicionCentro, radio, ghostBT.layerPlayer);

        // Recorrer los colliders encontrados y hacer algo con ellos
        foreach (Collider col in colliders)
        {
            if(col.gameObject.name == "Chomp"){
                ghostBT.SetData("target",col.gameObject.transform) ;
                state = NodeState.SUCCESS;
                break;
            }
        }

        
        return state;
    }
}
