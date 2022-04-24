using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (PlayerLauncher.instance.Player == null)
            return;

        if (col.relativeVelocity.magnitude > 2 && PlayerLauncher.instance.Player.launching)
        {
            GameManager.instance.DestroyEnemy(this);
        }
    }
}
