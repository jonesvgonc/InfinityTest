using System.Linq;
using UnityEditor;
using UnityEngine;

public class LevelCreationManager : MonoBehaviour
{
    public static LevelCreationManager Instance;

    [SerializeField]
    private GameObject _machinePrefab;
    [SerializeField]
    private GameObject _powerSourcePrefab;
    [SerializeField]
    private Transform _piecesParent;

    public LevelManager LevelManager;   

    public void Awake()
    {
        Instance = this;
    }

    public void MountLevel()
    {
        var level = LevelManager.LevelObjects.First(x=> x.LevelId == GameDataManager.Instance.ActualLevel);

        GameDataManager.Instance.LevelConnections = 0;
        GameDataManager.Instance.LevelConnectionsMade = 0;

        foreach (var piece in level.LevelObjects)
        {
            var position = new Vector2(GameDataManager.Instance.StartXPosition + piece.PositionX, GameDataManager.Instance.StartYPosition - piece.PositionY);
            var prefab = piece.PrefabId == 0 ? _powerSourcePrefab : _machinePrefab;

            GameDataManager.Instance.LevelConnections += piece.PrefabId == 0 ? 2 : 0;

            Instantiate(prefab, position, Quaternion.identity, _piecesParent);
        }
    }

    public void DestroyLevel()
    {
        var childCount = _piecesParent.childCount;

        for(var index = childCount -1; index > -1; index--)
        {
            Destroy(_piecesParent.GetChild(index).gameObject);
        }
    }
    

}
