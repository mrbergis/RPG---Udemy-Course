using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();

        _player.ZeroVelocity();
    }

    public override void Update()
    {
        base.Update();
        
        if(_xInput == _player.facingDir && _player.IsWallDetected())
            return;
        
        if(_xInput != 0 && !_player.IsBusy)
            _stateMachine.ChangeState(_player.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
