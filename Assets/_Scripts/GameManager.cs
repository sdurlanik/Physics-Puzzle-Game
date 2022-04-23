using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private List<GameObject> _availablePlayers = new List<GameObject>();

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
        SpawnNewPlayer();
    }
}
