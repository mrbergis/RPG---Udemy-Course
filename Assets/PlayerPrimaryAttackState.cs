using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int _comboCounter;

    private float _lastTimeAttacked;
    private float _comboWindow = 2;
    
    public PlayerPrimaryAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (_comboCounter > 2 || Time.time > _lastTimeAttacked + _comboWindow)
            _comboCounter = 0;
        
        _player.Anim.SetInteger("ComboCounter", _comboCounter);
    }

    public override void Update()
    {
        base.Update();
        
        if(_triggerCalled)
            _stateMachine.ChangeState(_player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();

        _comboCounter++;
        _lastTimeAttacked = Time.time;
    }
}
