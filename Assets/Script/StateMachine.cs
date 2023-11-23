using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    Idle,
    Run,
    Attack01,
    Attack02,
    Attack03,
    Slide,
    Stand,
    Jump,
    Fall
}

public class StateMachine : MonoBehaviour
{
    PlayerController pi;
    Dictionary<PlayerState, State> stateDictionary = new Dictionary<PlayerState, State>();
    State currentState;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        pi = GetComponent<PlayerController>();

        stateDictionary.Add(PlayerState.Idle, new State_Idle(pi, animator, this, Animator.StringToHash(AnimationString.idle)));
        stateDictionary.Add(PlayerState.Run, new State_Run(pi, animator, this, Animator.StringToHash(AnimationString.run)));
        stateDictionary.Add(PlayerState.Attack01, new State_Attack01(pi, animator, this, Animator.StringToHash(AnimationString.Attack01)));
        stateDictionary.Add(PlayerState.Attack02, new State_Attack02(pi, animator, this, Animator.StringToHash(AnimationString.Attack02)));
        stateDictionary.Add(PlayerState.Attack03, new State_Attack03(pi, animator, this, Animator.StringToHash(AnimationString.Attack03)));
        stateDictionary.Add(PlayerState.Slide, new State_Slide(pi, animator, this, Animator.StringToHash(AnimationString.Slide)));
        stateDictionary.Add(PlayerState.Stand, new State_Stand(pi, animator, this, Animator.StringToHash(AnimationString.Stand)));
        stateDictionary.Add(PlayerState.Jump, new State_Jump(pi, animator, this, Animator.StringToHash(AnimationString.Jump)));
        stateDictionary.Add(PlayerState.Fall, new State_Fall(pi, animator, this, Animator.StringToHash(AnimationString.Fall)));
    }

    private void Start()
    {
        ChangeState(PlayerState.Idle);
    }

    private void Update()
    {
        currentState.GameLogic();
    }

    private void FixedUpdate()
    {
        currentState.PhysicsLogic();
    }

    public void ChangeState(PlayerState newState)
    {
        if (currentState != null)
            currentState.BeforeExit();

        currentState = stateDictionary[newState];
        currentState.BeforeEnter();
    }
}