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
        if(LevelCreationManager.Instance.LevelManager.LevelObjects != null)
        {
            LevelCreationManager.Instance.MountLevel();
        }
    }

    public void LevelEnd()
    {
        ParticleManager.Instance.EndLevelCommemoration();
    }

}
