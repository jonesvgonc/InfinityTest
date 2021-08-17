using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameLevel
{
    [SerializeField]
    public int LevelId;
    [SerializeField]
    public List<LevelObjectPositions> LevelObjects;
}
