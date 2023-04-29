using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float _cooldownTimer;

    protected Player _player;

    protected virtual void Start()
    {
        _player = PlayerManager.Instance.player;
    }

    protected virtual void Update()
    {
        _cooldownTimer -= Time.deltaTime;
    }

    public virtual bool CanUseSkill()
    {
        if (_cooldownTimer < 0)
        {
            UseSkill();
            _cooldownTimer = cooldown;
            return true;
        }

        Debug.Log("Skill is on cooldown");
        
        return false;
    }

    public virtual void UseSkill()
    {
        // do some skill specific things
        
    }
}
