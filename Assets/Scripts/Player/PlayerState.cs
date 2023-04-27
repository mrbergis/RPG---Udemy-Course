using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;

    protected Rigidbody2D _rb;

    protected float _xInput;
    protected float _yInput;
    private string _animBoolName;

    protected float _stateTimer;
    protected bool _triggerCalled;
    
    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        _player.Anim.SetBool(_animBoolName, true);
        _rb = _player.Rb;
        _triggerCalled = false;
    }

    public virtual void Update()
    {
        _stateTimer -= Time.deltaTime;
        
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");
        _player.Anim.SetFloat("yVelocity", _rb.velocity.y);
    }

    public virtual void Exit()
    {
        _player.Anim.SetBool(_animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        _triggerCalled = true;
    }
}
