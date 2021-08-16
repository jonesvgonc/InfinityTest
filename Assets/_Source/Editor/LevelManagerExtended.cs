using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(LevelManager))]
public class LevelManagerExtended : Editor
{
    private string _pathFile = "Assets/Levels/LevelController.asset";
    private string _path = "Assets/Levels/";

    private int numberOfLevels = 10;

    private LevelManager levelManager { get { return (LevelManager)target; } }

    /// <summary>
    /// Creating a list of levels to the game
    /// </summary>
    /// <param name="value">Number of Levels will be created</param>
    public void CreateLevels(int value)
    {
        var nextLevel = 1;
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }

        ((LevelManager)(target)).LevelObjects = new System.Collections.Generic.List<GameLevel>();
        ((LevelManager)(target)).result = 1;
        for (var index = 0; index < value; index++)
        {
            var gameLevel = new GameLevel();
            gameLevel.LevelObjects = new System.Collections.Generic.List<LevelObjectPositions>();

            gameLevel.LevelId = nextLevel;

            var levelPowerSourcesCount = nextLevel + Random.Range(0, 2);
            if (levelPowerSourcesCount > 13) levelPowerSourcesCount = 13;
            var occupiedPositions = new int[40];
            SetPiecePosition(gameLevel, levelPowerSourcesCount, occupiedPositions, 0);

            SetPiecePosition(gameLevel, levelPowerSourcesCount * 2, occupiedPositions, 1);

            ((LevelManager)(target)).LevelObjects.Add(gameLevel);
            nextLevel++;
        }
    }

    /// <summary>
    /// this method randomizes a position to the game pieces.
    /// </summary>
    /// <param name="gameLevel">The level created itself</param>
    /// <param name="levelPieceCount">The count of that kind of piece created</param>
    /// <param name="occupiedPositions">An array of the positions of the positions mapping to that map</param>
    /// <param name="pieceType"> It is the type of piece, 0 to Power Generator and 1 to Machine</param>
    private static void SetPiecePosition(GameLevel gameLevel, int levelPieceCount, int[] occupiedPositions, int pieceType)
    {
        for (int index = 0; index < levelPieceCount; index++)
        {
            var getPosition = false;
            var objectPosition = new LevelObjectPositions();
            while (!getPosition)
            {
                var positionX = Random.Range(0, 5);
                var positionY = Random.Range(0, 8);

                if (occupiedPositions[(positionY * 5) + positionX] != 1)
                {
                    occupiedPositions[(positionY * 5) + positionX] = 1;
                    objectPosition.PrefabId = pieceType;
                    objectPosition.PositionX = positionX;
                    objectPosition.PositionY = positionY;
                    getPosition = true;
                }
            }

            gameLevel.LevelObjects.Add(objectPosition);
        }
    }

    public void TestLevels()
    {
        string[] result = AssetDatabase.FindAssets("LevelController");
        if (result.Length != 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(result[0]);
            var dataManager = (LevelManager)AssetDatabase.LoadAssetAtPath(path, typeof(LevelManager));

            if (dataManager.result != 0) Debug.Log("result good!");

            if (dataManager.LevelObjects != null)
            {
                Debug.Log("not null");
            }
        }
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical();

        numberOfLevels = EditorGUILayout.DelayedIntField("Quantity of Levels", numberOfLevels);

        if (GUILayout.Button("Create"))
        {
            CreateLevels(numberOfLevels);
            EditorUtility.SetDirty(target);
        }

        if (GUILayout.Button("Test"))
        {
            TestLevels();
        }

        GUILayout.EndVertical();
    }
}
