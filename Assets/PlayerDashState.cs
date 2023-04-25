using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _stateTimer = _player.dashDuration;
    }

    public override void Update()
    {
        base.Update();
        
        _player.SetVelocity(_player.dashSpeed * _player.facingDir, _rb.velocity.y);
        
        if (_stateTimer < 0)
            _stateMachine.ChangeState(_player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
        
        _player.SetVelocity(0, _rb.velocity.y);
    }
}
