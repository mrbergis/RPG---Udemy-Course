using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer _sr;

    [Header("Flash FX")] 
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    private Material _originalMat;

    private void Start()
    {
        _sr = GetComponentInChildren<SpriteRenderer>();
        _originalMat = _sr.material;
    }

    private IEnumerator FlashFX()
    {
        _sr.material = hitMat;

        yield return new WaitForSeconds(flashDuration);

        _sr.material = _originalMat;
    }

    private void RedColorBlink()
    {
        if(_sr.color != Color.white)
            _sr.color = Color.white;
        else 
            _sr.color = Color.red;
    }

    private void CancelRedBlink()
    {
        CancelInvoke();
        _sr.color = Color.white;
    }
}
