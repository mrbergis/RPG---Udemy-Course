using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Stunned info")] 
    public float stunDuration;
    public Vector2 stunDirection;
    
    [Header("Move info")] 
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack info")] 
    public float attackDistance;
    public float attackCooldown;
    [HideInInspector]public float lastTimeAttacked;
    
    public EnemyStateMachine StateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        StateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        
        StateMachine.CurrentState.Update();
    }

    public virtual void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

    public virtual RaycastHit2D IsPlayerDetected()
        => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, 50, whatIsPlayer);

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir,transform.position.y));
    }
}
