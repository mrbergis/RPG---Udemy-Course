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

        _rb.velocity = new Vector2(0, 0);
    }

    public override void Update()
    {
        base.Update();
        
        if(_xInput == _player.facingDir && _player.IsWallDetected())
            return;
        
        if(_xInput != 0)
            _stateMachine.ChangeState(_player.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
