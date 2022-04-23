using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _offset = 2.0f;

    public static CameraController instance;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if (_player == null)
            return;

        if (_player.launching && _player.transform.position.x >= transform.position.x - _offset)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(_player.transform.position.x + _offset, 1, -10), Time.deltaTime * 10);
        }
    }

    public void SetPlayer(Player newPlayer)
    {
        _player = newPlayer;
        Vector3 newPos = _player.transform.position;
        newPos.z = -10;

        transform.position = newPos;
    }
}
