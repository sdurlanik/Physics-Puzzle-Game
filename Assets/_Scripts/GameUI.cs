using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject _nextPlayerButton;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _gameOverText;

    public static GameUI instance;

    public GameObject NextPlayerButton
    {
        get => _nextPlayerButton;
        set => _nextPlayerButton = value;
    }

    private void Awake()
    {
        instance = this;
    }

    public void OnNextPlayerButton()
    {
        GameManager.instance.SpawnNewPlayer();
        NextPlayerButton.SetActive(false);
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetEndScreen(bool didWin)
    {
        _endScreen.SetActive(true);
        _winText.SetActive(didWin);
        _gameOverText.SetActive(!didWin);
    }
}
