using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
   #region Components
   public Animator Anim { get; private set; }
   public Rigidbody2D Rb { get; private set; }

   #endregion
   
   [Header("Collision info")] 
   public Transform attackCheck;
   public float attackCheckRadius;
   [SerializeField] protected Transform groundCheck;
   [SerializeField] protected float groundCheckDistance;
   [SerializeField] protected Transform wallCheck;
   [SerializeField] protected float wallCheckDistance;
   [SerializeField] protected LayerMask whatIsGround;
   
   public int facingDir { get; private set; } = 1;
   protected bool _facingRight = true;
   
   protected virtual void Awake()
   {
      
   }

   protected virtual void Start()
   {
      Anim = GetComponentInChildren<Animator>();
      Rb = GetComponent<Rigidbody2D>();
   }

   protected virtual void Update()
   {
      
   }

   public virtual void Damage()
   {
      Debug.Log(gameObject.name + " was damaged!");
   }
   
   #region Velocity

   public void SetZeroVelocity() => Rb.velocity = Vector2.zero;//new Vector2(0,0);
   public void SetVelocity(float xVelocity, float yVelocity)
   {
      Rb.velocity = new Vector2(xVelocity, yVelocity);
      FlipController(xVelocity);
   }

   #endregion
   
   #region Collision
   public virtual bool IsGroundDetected() 
      => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance,whatIsGround);
    
   public virtual bool IsWallDetected() 
      => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir, wallCheckDistance,whatIsGround);
    
   protected virtual void OnDrawGizmos()
   {
      Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
      Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position. x + wallCheckDistance, wallCheck.position.y));
      Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
   }
   #endregion
   
   #region Flip
   public virtual void Flip()
   {
      facingDir = facingDir * -1;
      _facingRight = !_facingRight;
      transform.Rotate(0 , 180, 0);
   }

   public virtual void FlipController(float x)
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
   
   #endregion
   

}
