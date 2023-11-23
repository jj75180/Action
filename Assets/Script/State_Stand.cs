using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Stand : State
{
    public State_Stand(PlayerController pi, Animator animator, StateMachine stateMachine, int stateName)
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
            stateMachine.ChangeState(PlayerState.Idle);
            return;
        }
    }
    public override void PhysicsLogic() { }
    public override void BeforeExit()
    {
        pi.TurnStateMachine(AnimationString.isSlide, false);
        countTime = 0;
    }
}