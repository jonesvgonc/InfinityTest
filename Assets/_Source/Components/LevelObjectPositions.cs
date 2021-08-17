using System;
using UnityEngine;

[Serializable]
public class LevelObjectPositions
{
    [SerializeField]
    private int _prefabId;
    [SerializeField]
    private int _positionX;
    [SerializeField]
    private int _positionY;

    public int PrefabId { get => _prefabId; set => _prefabId = value; }
    public int PositionX { get => _positionX; set => _positionX = value; }
    public int PositionY { get => _positionY; set => _positionY = value; }
}
