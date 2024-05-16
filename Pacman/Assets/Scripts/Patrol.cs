using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Patrol : Node
{
        public Patrol(BTree bTree) : base(bTree) { }

        public Patrol(BTree bTree, List<Node> children) : base(bTree, children) { }

        public Patrol(BTree bTree, Node child) : base(bTree, child) { }

        public override NodeState Evaluate()
        {
            // Implementa la lógica de evaluación para el nodo compuesto aquí
            // Por ejemplo, puedes iterar sobre los hijos y evaluarlos individualmente
            foreach (Node child in children)
            {
                NodeState childState = child.Evaluate();
                if (childState != NodeState.SUCCESS)
                    return childState;
            }

            return NodeState.SUCCESS; // Si todos los hijos tienen éxito, este nodo también tiene éxito
        }
    }
