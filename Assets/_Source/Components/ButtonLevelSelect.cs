using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLevelSelect : MonoBehaviour
{
    private int _levelId;

    private SelectLevelViewModel _selectLevelViewModel;

    public int LevelId { get => _levelId; set => _levelId = value; }
    public SelectLevelViewModel SelectLevelViewModel { get => _selectLevelViewModel; set => _selectLevelViewModel = value; }

    public void StartLevel()
    {
        GameManager.Instance.StartInLevel(_levelId);
        SelectLevelViewModel.DestroyUI();
        UIManager.Instance.SetInGameUI();
    }
}
