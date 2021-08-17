using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuModel : MonoBehaviour
{
    [SerializeField]
    private Button _startGameButton;

    [SerializeField]
    private Button _selectLevelButton;

    [SerializeField]
    private Button _quitGameButton;

    public Button StartGameButton { get => _startGameButton; set => _startGameButton = value; }
    public Button SelectLevelButton { get => _selectLevelButton; set => _selectLevelButton = value; }
    public Button QuitGameButton { get => _quitGameButton; set => _quitGameButton = value; }
}
