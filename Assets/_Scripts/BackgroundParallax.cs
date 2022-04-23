using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private float _parallaxRate = 1.2f;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        transform.position = new Vector3(_cam.transform.position.x / _parallaxRate, 0, 0);
    }
}
