using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public PlayInput playinput;
    public float moveSpeed;
    public float Force;
    private Vector3 moveInput;
    private Vector3 moveX;

    Animator StateMachine;
    private Rigidbody rd;
    public LayerMask Ground;
    public bool isMoving
    {
        get
        {
            return StateMachine.GetBool(AnimationString.isMoving);
        }
    }
    public bool isAttack
    {
        get
        {
            return StateMachine.GetBool(AnimationString.isAttack);
        }
    }
    public bool isRightDir
    {
        get
        {
            return transform.localScale.Equals(new Vector3(1, 1, 1));
        }
    }

    public bool isSlide
    {
        get
        {
            return StateMachine.GetBool(AnimationString.isSlide);
        }
    }

    public bool isJump
    {
        get
        {
            return StateMachine.GetBool(AnimationString.isJump);
        }
    }
    public bool isGround
    {
        get
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.07f, Ground))
            {
                return true;
            }
            return false;
        }

    }

    private void OnEnable()
    {
        playinput.Enable();
    }
    private void OnDisable()
    {
        playinput.Disable();
    }
    private void Awake()
    {

        rd = GetComponent<Rigidbody>();
        StateMachine = GetComponent<Animator>();
        playinput = new PlayInput();
        playinput.Player.Attack.started += OnAttackStart;
        playinput.Player.Slide.started += OnSlideStart;
        playinput.Player.Jump.started += OnJumpStart;
    }

    private void OnJumpStart(InputAction.CallbackContext context)
    {
        StateMachine.SetBool(AnimationString.isJump, true);
    }

    private void OnSlideStart(InputAction.CallbackContext context)
    {
        if (isSlide || isAttack)
        {
            return;
        }
        StopMove();
        StateMachine.SetBool(AnimationString.isSlide, true);
    }

    private void OnAttackStart(InputAction.CallbackContext context)
    {
        if (isSlide)
        {
            return;
        }
        StopMove();
        StateMachine.SetBool(AnimationString.isAttack, true);
    }

    private void Update()
    {
        Move();
        CheckOnAir();
    }

    private void CheckOnAir()
    {

    }

    public void Move()
    {
        if (isSlide)
        {
            return;
        }
        moveInput = playinput.Player.Movement.ReadValue<Vector3>().normalized;
        moveX = new Vector3(moveInput.x, 0, 0);
        StateMachine.SetBool(AnimationString.isMoving, moveX != Vector3.zero);
        faceDir();
    }
    public void Movement()
    {
        rd.velocity = moveX * moveSpeed + new Vector3(0, rd.velocity.y, 0);
    }
    public void StopMove()
    {
        rd.velocity = Vector3.zero;
    }
    public void MoveCurve(Vector3 Dir, float force)
    {
        rd.AddForce(Dir * force, ForceMode.Impulse);
    }
    public void faceDir()
    {
        int faceDir = (int)transform.localScale.x;

        if (moveInput.x > 0)
            faceDir = 1;
        if (moveInput.x < 0)
            faceDir = -1;

        transform.localScale = new Vector3(faceDir, 1, 1);
    }

    public void TurnStateMachine(string animationClip, bool value)
    {
        StateMachine.SetBool(animationClip, value);
    }
}