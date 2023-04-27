using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject _cam;

    [SerializeField] private float parallaxEffect;

    private float _xPosition;
    private float length;
    
    void Start()
    {
        _cam = GameObject.Find("Main Camera");

        length = GetComponent<SpriteRenderer>().bounds.size.x;

        _xPosition = transform.position.x;
    }

    
    void Update()
    {
        float distanceMoved = _cam.transform.position.x * (1 - parallaxEffect);
        float distanceToMove = _cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(_xPosition + distanceToMove,transform.position.y);

        if (distanceMoved > _xPosition + length)
            _xPosition = _xPosition + length;
        else if (distanceMoved < _xPosition - length)
            _xPosition = _xPosition - length;
    }
}
