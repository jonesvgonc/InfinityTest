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
        GameDataManager.Instance.ActualLevel++;
        StartCoroutine(NextGame());
    }

    public IEnumerator NextGame()
    {
        yield return new WaitForSeconds(7);
        LevelCreationManager.Instance.DestroyLevel();
        LevelCreationManager.Instance.MountLevel();
    }

}
