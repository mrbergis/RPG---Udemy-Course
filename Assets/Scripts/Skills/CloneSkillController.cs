using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CloneSkillController : MonoBehaviour
{
    private SpriteRenderer _sr;
    private Animator _anim;
    
    [SerializeField] private float colorLoosingSpeed;
    
    private float _cloneTimer;
    [SerializeField] private Transform attackCheck;
    [SerializeField] private float attackCheckRadius = .8f;
    private Transform _closestEnemy;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _cloneTimer -= Time.deltaTime;

        if (_cloneTimer < 0)
        {
            _sr.color = new Color(1, 1, 1, _sr.color.a - (Time.deltaTime * colorLoosingSpeed));
            
            if(_sr.color.a < 0)
                Destroy(gameObject);
        }
          
        
    }

    public void SetupClone(Transform newTransform, float cloneDuration, bool canAttack)
    {
        if(canAttack)
            _anim.SetInteger("AttackNumber",Random.Range(1,3));
        
        transform.position = newTransform.position;
        _cloneTimer = cloneDuration;

        FaceClosetTarget();
    }
    
    private void AnimationTrigger()
    {
        _cloneTimer = -.1f;
    }
    
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackCheck.position, attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().Damage();
        }
    }

    private void FaceClosetTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 25);

        float closestDistance = Mathf.Infinity;

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, hit.transform.position);

                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    _closestEnemy = hit.transform;
                }
                    
            }
        }

        if (_closestEnemy != null)
        {
            if(transform.position.x > _closestEnemy.position.x)
                transform.Rotate(0,180,0);
        }
    }
    
}
