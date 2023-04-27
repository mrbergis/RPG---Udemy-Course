using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : EnemyState
{
    private EnemySkeleton _enemy;
    
    public SkeletonMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemy, stateMachine, animBoolName)
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
        
        _enemy.SetVelocity(_enemy.moveSpeed * _enemy.facingDir, _enemy.Rb.velocity.y);

        if (_enemy.IsWallDetected() || !_enemy.IsGroundDetected())
        {
            _enemy.Flip();
            _stateMachine.ChangeState(_enemy.IdleState);
        }
            
    }

    public override void Exit()
    {
        base.Exit();
    }
}
 