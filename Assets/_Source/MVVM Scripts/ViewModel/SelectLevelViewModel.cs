using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelViewModel : MonoBehaviour
{
    [SerializeField]
    private GameObject _selectLevelView;

    private SelectLevelModel _selectLevelModel;

    public void StartSelectLevelMenu()
    {
        var gameObj = Instantiate(_selectLevelView);
        _selectLevelModel = gameObj.GetComponent<SelectLevelModel>();

        foreach(var level in LevelCreationManager.Instance.LevelManager.LevelObjects)
        {
            var btn = Instantiate(_selectLevelModel.LevelButton, _selectLevelModel.ButtonsPanel);
            btn.GetComponent<ButtonLevelSelect>().LevelId = level.LevelId;
            btn.GetComponent<ButtonLevelSelect>().SelectLevelViewModel = this;
            if(level.LevelId > GameDataManager.Instance.PlayerStats.LastLevelCompleted + 1)
            {
                btn.GetComponent<Button>().enabled = false;
            }else if(level.LevelId <= GameDataManager.Instance.PlayerStats.LastLevelCompleted)
            {
                btn.transform.GetChild(1).gameObject.SetActive(true);
            }

            btn.transform.GetChild(0).GetComponent<Text>().text = level.LevelId.ToString();
        }
    }

    public void DestroyUI()
    {
        Destroy(_selectLevelModel.gameObject);
    }
}
