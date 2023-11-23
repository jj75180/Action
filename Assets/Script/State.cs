using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public float countTime,clipLength;
    public PlayerController pi;
    public Animator animator;
    public StateMachine stateMachine;
    public int stateName;
    public DirectionController directionController;

    public virtual void BeforeEnter() { }
    public virtual void GameLogic() { }
    public virtual void PhysicsLogic() { }
    public virtual void BeforeExit() { }
}