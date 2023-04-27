using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : EnemyState
{
    private EnemySkeleton _enemy;
    
    public SkeletonIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemy, stateMachine, animBoolName)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        _stateTimer = _enemy.idleTime;
    }

    public override void Update()
    {
        base.Update();
        
        if(_stateTimer < 0)
            _stateMachine.ChangeState(_enemy.MoveState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
