using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine _stateMachine;
    protected Enemy _enemy;

    private string _animBoolName;

    protected float _stateTimer;
    protected bool _triggerCalled;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        _enemy = enemy;
        _stateMachine = stateMachine;
        _animBoolName = animBoolName;
    }
    
    public virtual void Enter()
    {
        _triggerCalled = false;
        _enemy.Anim.SetBool(_animBoolName, true);
    }

    public virtual void Update()
    {
        _stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        _enemy.Anim.SetBool(_animBoolName, false);
    }
}
