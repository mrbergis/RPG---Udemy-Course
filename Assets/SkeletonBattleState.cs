using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private Transform _player;
    private EnemySkeleton _enemy;
    private int _moveDir;
    
    public SkeletonBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemy, stateMachine, animBoolName)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        _player = GameObject.Find("Player").transform;
    }

    public override void Update()
    {
        base.Update();

        if (_enemy.IsPlayerDetected())
        {
            if (_enemy.IsPlayerDetected().distance < _enemy.attackDistance)
            {
                if(CanAttack())
                    _stateMachine.ChangeState(_enemy.AttackState);
            }
        }
        
        if (_player.position.x > _enemy.transform.position.x)
            _moveDir = 1;
        else if (_player.position.x < _enemy.transform.position.x)
            _moveDir = -1;
        
        _enemy.SetVelocity(_enemy.moveSpeed * _moveDir, _rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if (Time.time >= _enemy.lastTimeAttacked + _enemy.attackCooldown)
        {
            _enemy.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}
