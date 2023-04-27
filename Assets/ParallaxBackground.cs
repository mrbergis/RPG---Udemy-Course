using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private GameObject _cam;

    [SerializeField] private float parallaxEffect;

    private float _xPosition;
    
    void Start()
    {
        _cam = GameObject.Find("Main Camera");

        _xPosition = transform.position.x;
    }

    
    void Update()
    {
        float distanceToMove = _cam.transform.position.x * parallaxEffect;

        transform.position = new Vector3(_xPosition + distanceToMove,transform.position.y);
    }
}
