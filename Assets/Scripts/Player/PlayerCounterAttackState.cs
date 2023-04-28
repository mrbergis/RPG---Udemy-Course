using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    public PlayerCounterAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _stateTimer = _player.counterAttackDuration;
        _player.Anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Update()
    {
        base.Update();
        
        _player.SetZeroVelocity();
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_player.attackCheck.position, _player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                if (hit.GetComponent<Enemy>().CanBeStunned())
                {
                    _stateTimer = 10; // any value bigger than 1
                    _player.Anim.SetBool("SuccessfulCounterAttack", true);
                }
            }
        }
        if(_stateTimer < 0 || _triggerCalled)
            _stateMachine.ChangeState(_player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
