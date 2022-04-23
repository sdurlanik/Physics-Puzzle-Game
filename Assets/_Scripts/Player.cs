using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rig;
    public bool launching;

    private void Awake()
    {
        _rig.isKinematic = true;
    }

    void Update()
    {
        if (launching && _rig.IsSleeping())
        {
            GameManager.instance.PlayerFinished();
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction)
    {
        _rig.isKinematic = false;
        _rig.AddForce(direction * 5, ForceMode2D.Impulse);
        launching = true;
    }
}
