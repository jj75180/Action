using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Slide : State
{
    float force = 0.5f;
    public State_Slide(PlayerController pi, Animator animator, StateMachine stateMachine, int stateName)
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
        countTime += Time.deltaTime;
        if (animator.IsInTransition(0))
        {
            clipLength = animator.GetNextAnimatorStateInfo(0).length;
        }

        if (countTime > clipLength)
        {
            stateMachine.ChangeState(PlayerState.Stand);
            return;
        }
    }
    public override void PhysicsLogic()
    {
        if (pi.isRightDir)
            pi.MoveCurve(new Vector3(1, 0, 0), force);
        else
            pi.MoveCurve(new Vector3(-1, 0, 0), force);
    }
    public override void BeforeExit()
    {
        pi.StopMove();
        pi.TurnStateMachine(AnimationString.isSlide, false);
        countTime = 0;
    }
}