using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonStunnedState : EnemyState
{
    protected EnemySkeleton _enemy;
    
    public SkeletonStunnedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemy, stateMachine, animBoolName)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        
        _enemy.FX.InvokeRepeating("RedColorBlink", 0,.1f);

        _stateTimer = _enemy.stunDuration;
        
        _rb.velocity= new Vector2(-_enemy.facingDir * _enemy.stunDirection.x,_enemy.stunDirection.y);
    }

    public override void Update()
    {
        base.Update();
        
        if(_stateTimer < 0)
            _stateMachine.ChangeState(_enemy.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
        
        _enemy.FX.Invoke("CancelRedBlink",0);
    }
}
