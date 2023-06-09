using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimSwordState : PlayerState
{
    public PlayerAimSwordState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        if(Input.GetKeyUp(KeyCode.Mouse1))
            _stateMachine.ChangeState(_player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
