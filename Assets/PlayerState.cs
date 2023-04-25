using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;

    protected Rigidbody2D _rb;

    protected float _xInput;
    private string _animBoolName;

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
    }

    public virtual void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _player.Anim.SetFloat("yVelocity", _rb.velocity.y);
    }

    public virtual void Exit()
    {
        _player.Anim.SetBool(_animBoolName, false);
    }
}
