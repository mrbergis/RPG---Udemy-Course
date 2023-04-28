using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    private EnemySkeleton _enemy;
    
    public SkeletonAttackState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemy, stateMachine, animBoolName)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        
        _enemy.SetZeroVelocity();
        
        if (_triggerCalled)
            _stateMachine.ChangeState(_enemy.BattleState);
    }

    public override void Exit()
    {
        base.Exit();

        _enemy.lastTimeAttacked = Time.time;
    }
}
