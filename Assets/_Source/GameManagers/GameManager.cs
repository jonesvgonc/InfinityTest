using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        var playerData = SaveLoadGame.LoadGame();
        if(playerData == null)
        {
            GameDataManager.Instance.PlayerStats = new PlayerStats() { ActualLevel = 1, LastLevelCompleted = 0 };
            SaveLoadGame.SaveGame(GameDataManager.Instance.PlayerStats);
        }else
        {
            GameDataManager.Instance.PlayerStats = playerData;
            GameDataManager.Instance.ActualLevel = playerData.LastLevelCompleted++;
        }
    }

    public void StartGame()
    {
        if (LevelCreationManager.Instance.LevelManager.LevelObjects != null)
        {
            LevelCreationManager.Instance.MountLevel();
        }
    }

    public void StartInLevel(int level)
    {
        GameDataManager.Instance.ActualLevel = level;
        LevelCreationManager.Instance.MountLevel();
    }

    public void LevelEnd()
    {
        ParticleManager.Instance.EndLevelCommemoration();

        if (GameDataManager.Instance.ActualLevel > GameDataManager.Instance.PlayerStats.LastLevelCompleted)
            GameDataManager.Instance.PlayerStats.LastLevelCompleted++;

        GameDataManager.Instance.ActualLevel++;
        GameDataManager.Instance.PlayerStats.ActualLevel = GameDataManager.Instance.ActualLevel;
        
        SaveLoadGame.SaveGame(GameDataManager.Instance.PlayerStats);
        AudioManager.Instance.PlayCommemorations();
        UIManager.Instance.LevelSuccess();
        StartCoroutine(CameraShake.Instance.Shake(1f, 0.2f));
        StartCoroutine(NextGame());
    }

    public IEnumerator NextGame()
    {
        yield return new WaitForSeconds(7);
        LevelCreationManager.Instance.DestroyLevel();
        LevelCreationManager.Instance.MountLevel();
        UIManager.Instance.ChangeLevelText();
    }
}
