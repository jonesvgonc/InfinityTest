using System;

[Serializable]
public class LevelObjectPositions
{
    private int _prefabId;
    private int _positionX;
    private int _positionY;

    public int PrefabId { get => _prefabId; set => _prefabId = value; }
    public int PositionX { get => _positionX; set => _positionX = value; }
    public int PositionY { get => _positionY; set => _positionY = value; }
}
