using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonAnimationTriggers : MonoBehaviour
{
    private EnemySkeleton _enemy => GetComponentInParent<EnemySkeleton>();

    private void AnimationTrigger()
    {
        _enemy.AnimationFinishTrigger();
    }
    
}
