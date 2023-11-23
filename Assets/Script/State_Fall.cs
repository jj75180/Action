using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Fall : State
{
    public State_Fall(PlayerController pi,Animator animator, StateMachine stateMachine, int stateName)
    {
        this.pi = pi;
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }
    public override void BeforeEnter()
    {
        animator.CrossFade(stateName,0.1f,0,0.1f);
    }
    public override void GameLogic()
    {
        if(pi.isGround)
        {
            stateMachine.ChangeState(PlayerState.Idle);
            return;
        }
    }
    public override void PhysicsLogic()
    {

    }
    public override void BeforeExit()
    {

    }
}