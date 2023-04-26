using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        _player.SetVelocity(_xInput * _player.moveSpeed, _rb.velocity.y);
        
        if(_xInput == 0 || _player.IsWallDetected())
            _stateMachine.ChangeState(_player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
