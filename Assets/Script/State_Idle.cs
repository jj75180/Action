using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : State
{
    public State_Idle(PlayerController pi,Animator animator, StateMachine stateMachine, int stateName)
    {
        this.pi = pi;
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }
    public override void BeforeEnter()
    {
        pi.StopMove();
        animator.CrossFade(stateName,0.1f,0,0.1f);
    }
    public override void GameLogic()
    {
        if(pi.isMoving)
        {
            stateMachine.ChangeState(PlayerState.Run);
            return;
        }
        if(pi.isAttack)
        {
            stateMachine.ChangeState(PlayerState.Attack01);
            return;
        }
        if(pi.isSlide)
        {
            stateMachine.ChangeState(PlayerState.Slide);
            return;
        }
        if(pi.isJump)
        {
            stateMachine.ChangeState(PlayerState.Jump);
            return;
        }
        if(!pi.isGround)
        {
            stateMachine.ChangeState(PlayerState.Fall);
            return;
        }
    }
    public override void PhysicsLogic(){}
    public override void BeforeExit(){}
}