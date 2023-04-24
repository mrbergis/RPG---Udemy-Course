using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        if(Input.GetKeyDown(KeyCode.N))
            _stateMachine.ChangeState(_player.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
