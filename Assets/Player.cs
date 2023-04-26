using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Move info")] 
    public float moveSpeed = 12f;
    public float jumpForce;

    [Header("Dash info")] 
    [SerializeField] private float dashCooldown;
    private float _dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float DashDir { get; private set; }

    [Header("Collision info")] 
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    public int facingDir { get; private set; } = 1;
    private bool _facingRight = true;
    
    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D Rb { get; private set; }

    #endregion

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    #endregion
    
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        MoveState = new PlayerMoveState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState  = new PlayerAirState(this, StateMachine, "Jump");
        DashState = new PlayerDashState(this, StateMachine,"Dash");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, "WallSlide");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, "Jump");
    }

    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        
        StateMachine.Initialize(IdleState);
    }
    
    private void Update()
    {
        StateMachine.CurrentState.Update();

        CheckForDashInput();
    }

    private void CheckForDashInput()
    {
        if(IsWallDetected())
            return;
        
        _dashUsageTimer -= Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && _dashUsageTimer < 0)
        {
            _dashUsageTimer = dashCooldown;
            DashDir = Input.GetAxisRaw("Horizontal");

            if (DashDir == 0)
                DashDir = facingDir;
            
            StateMachine.ChangeState(DashState);
        }
            
    }
    
    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rb.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }

    public bool IsGroundDetected() 
        => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance,whatIsGround);
    
    public bool IsWallDetected() 
        => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance,whatIsGround);
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position. x + wallCheckDistance, wallCheck.position.y));
    }

    public void Flip()
    {
        facingDir = facingDir * -1;
        _facingRight = !_facingRight;
        transform.Rotate(0 , 180, 0);
    }

    public void FlipController(float x)
    {
        if (x > 0 && !_facingRight)
        {
            Flip();
        }
        else if (x < 0 && _facingRight)
        {
            Flip();
        }
        
    }
}
