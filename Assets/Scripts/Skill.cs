using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected float cooldown;
    protected float _cooldownTimer;

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
