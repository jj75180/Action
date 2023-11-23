using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Run : State
{
    public State_Run(PlayerController pi, Animator animator, StateMachine stateMachine, int stateName)
    {
        this.pi = pi;
        this.animator = animator;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
    }

    public override void BeforeEnter()
    {
        animator.CrossFade(stateName, 0.1f, 0, 0.1f);
    }

    public override void GameLogic()
    {
        if (!pi.isMoving)
        {
            stateMachine.ChangeState(PlayerState.Idle);
            return;
        }
        if (pi.isAttack)
        {
            stateMachine.ChangeState(PlayerState.Attack01);
            return;
        }
        if (pi.isSlide)
        {
            stateMachine.ChangeState(PlayerState.Slide);
        }
        if (pi.isJump)
        {
            stateMachine.ChangeState(PlayerState.Jump);
            return;
        }
    }

    public override void PhysicsLogic()
    {
        pi.Movement();
    }

    public override void BeforeExit()
    {
        // 在這裡可以添加離開狀態時的邏輯
    }
}