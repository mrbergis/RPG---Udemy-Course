using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkillController : MonoBehaviour
{
    private SpriteRenderer _sr;
    [SerializeField] private float colorLoosingSpeed;
    
    private float _cloneTimer;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _cloneTimer -= Time.deltaTime;

        if (_cloneTimer < 0)
        {
            _sr.color = new Color(1, 1, 1, _sr.color.a - (Time.deltaTime * colorLoosingSpeed));
        }
          
        
    }

    public void SetupClone(Transform newTransform, float cloneDuration)
    {
        transform.position = newTransform.position;
        _cloneTimer = cloneDuration;
    }
}
