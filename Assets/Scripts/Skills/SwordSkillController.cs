using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkillController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private CircleCollider2D _circleCollider;
    private Player _player;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    public void SetupSword(Vector2 direction, float gravityScale)
    {
        _rigidbody.velocity = direction;
        _rigidbody.gravityScale = gravityScale;
    }
}
