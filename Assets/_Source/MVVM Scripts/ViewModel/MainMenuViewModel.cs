using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuViewModel : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainMenuView;

    private MainMenuModel _mainMenuModel;

    public void StartMainMenu()
    {
        var gameObj = Instantiate(_mainMenuView);
        _mainMenuModel = gameObj.GetComponent<MainMenuModel>();

        _mainMenuModel.StartGameButton.onClick.AddListener(() => StartGame());
        _mainMenuModel.SelectLevelButton.onClick.AddListener(() => SelectLevel());
        _mainMenuModel.QuitGameButton.onClick.AddListener(() => QuitGame());
    }

    public void DestroyMainMenu()
    {
        Destroy(_mainMenuModel.gameObject);
    }

    public void StartGame()
    {
        DestroyMainMenu();
        GameManager.Instance.StartGame();
        UIManager.Instance.SetInGameUI();
    }

    public void SelectLevel()
    {
        DestroyMainMenu();
        UIManager.Instance.SetSelectLevelMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
