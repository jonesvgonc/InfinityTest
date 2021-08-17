using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField]
    private MainMenuViewModel _mainMenu;
    [SerializeField]
    private SelectLevelViewModel _selectLevel;
    [SerializeField]
    private InGameViewModel _inGameMenu;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _mainMenu.StartMainMenu();
    }

    public void SetInGameUI()
    {
        _inGameMenu.StartInGameUI();
    }

    public void LevelSuccess()
    {
        _inGameMenu.SuccessLevel();
    }

    public void SetSelectLevelMenu()
    {
        _selectLevel.StartSelectLevelMenu();
    }

    public void ChangeLevelText()
    {
        _inGameMenu.ChangeLevelText();
    }

    public void ChangeScoreText(int score)
    {
        _inGameMenu.ChangeScoreText(score);
    }
}
