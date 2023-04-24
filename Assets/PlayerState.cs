using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _stateMachine;
    protected Player _player;

    private string _animBoolName;

    public PlayerState(Player player, PlayerStateMachine stateMachine, string animBoolName)
    {
        _player = player;
        _stateMachine = stateMachine;
        _animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log("I enter " + _animBoolName);
    }

    public virtual void Update()
    {
        Debug.Log("I'm in " + _animBoolName);
    }

    public virtual void Exit()
    {
        Debug.Log("I exit " + _animBoolName);
    }
}
