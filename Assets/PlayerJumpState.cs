using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _rb.velocity = new Vector2(_rb.velocity.x, _player.jumpForce);
    }

    public override void Update()
    {
        base.Update();
        
        if(_rb.velocity.y < 0)
            _stateMachine.ChangeState(_player.AirState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
