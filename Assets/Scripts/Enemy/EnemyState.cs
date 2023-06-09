using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine _stateMachine;
    protected Enemy _enemyBase;
    protected Rigidbody2D _rb;

    private string _animBoolName;

    protected float _stateTimer;
    protected bool _triggerCalled;

    public EnemyState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName)
    {
        _enemyBase = enemyBase;
        _stateMachine = stateMachine;
        _animBoolName = animBoolName;
    }
    
    public virtual void Enter()
    {
        _triggerCalled = false;
        _rb = _enemyBase.Rb;
        _enemyBase.Anim.SetBool(_animBoolName, true);
    }

    public virtual void Update()
    {
        _stateTimer -= Time.deltaTime;
    }

    public virtual void Exit()
    {
        _enemyBase.Anim.SetBool(_animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        _triggerCalled = true;
    }
}
