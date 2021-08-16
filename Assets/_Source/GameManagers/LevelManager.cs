using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelController", menuName = "Levels/LevelController", order = 1)]
public class LevelManager : ScriptableObject
{
    public int result = 0;

    public List<GameLevel> LevelObjects;
}
