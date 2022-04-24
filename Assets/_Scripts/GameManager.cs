using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> _availablePlayers = new List<GameObject>();
    [SerializeField] private List<Enemy> _enemies = new List<Enemy>();

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnNewPlayer();
    }

    public void SpawnNewPlayer()
    {
        PlayerLauncher.instance.SetNewPlayer(_availablePlayers[0]);
        _availablePlayers.RemoveAt(0);
    }

    public void PlayerFinished()
    {
        //SpawnNewPlayer();
        if (_availablePlayers.Count > 0 && _enemies.Count > 0)
        {
            GameUI.instance.NextPlayerButton.SetActive(true);
        }
        else
        {
            GameUI.instance.SetEndScreen(_enemies.Count == 0);
        }
    }

    public void DestroyEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
