using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Jump : State
{
    float force = 0.5f;
    public State_Jump(PlayerController pi, Animator animator, StateMachine stateMachine, int stateName)
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
            stateMachine.ChangeState(PlayerState.Fall);
            return;
        }
    }
    public override void PhysicsLogic()
    {
        pi.MoveCurve(Vector3.up, force);
    }
    public override void BeforeExit()
    {
        pi.StopMove();
        pi.TurnStateMachine(AnimationString.isJump, false);
        countTime = 0;
    }
}
