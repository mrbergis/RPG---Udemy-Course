using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected EnemySkeleton _enemy;
    protected Transform _player;
    
    public SkeletonGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, EnemySkeleton enemy) : base(enemy, stateMachine, animBoolName)
    {
        _enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();

        _player = PlayerManager.Instance.player.transform;
    }

    public override void Update()
    {
        base.Update();
        
        if(_enemy.IsPlayerDetected() || Vector2.Distance(_enemy.transform.position, _player.position) < 2)
            _stateMachine.ChangeState(_enemy.BattleState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}