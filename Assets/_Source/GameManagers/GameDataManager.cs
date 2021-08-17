using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;

    private float _startXPosition = -2;
    private float _startYPosition = 3.5f;
    private int _actualLevel = 1;
    private int _levelConnections = 0;
    private int _levelConnectionsMade = 0;
    private bool _gameStarted = false;
    private PlayerStats _playerStats;

    public float StartXPosition { get => _startXPosition; set => _startXPosition = value; }
    public float StartYPosition { get => _startYPosition; set => _startYPosition = value; }
    public int ActualLevel { get => _actualLevel; set => _actualLevel = value; }
    public int LevelConnections { get => _levelConnections; set => _levelConnections = value; }
    public int LevelConnectionsMade { get => _levelConnectionsMade; set => _levelConnectionsMade = value; }
    public bool GameStarted { get => _gameStarted; set => _gameStarted = value; }
    public PlayerStats PlayerStats { get => _playerStats; set => _playerStats = value; }

    public void Awake()
    {
        Instance = this;
    }

    internal bool EndGame()
    {
        if (_levelConnectionsMade >= _levelConnections) return true;

        return false;
    }
}
