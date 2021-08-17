using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameModel : MonoBehaviour
{
    [SerializeField]
    private GameObject _successPanel;
    [SerializeField]
    private GameObject _startPanel;
    [SerializeField]
    private Text _levelText;
    [SerializeField]
    private Text _scoreText;

    public GameObject SuccessPanel { get => _successPanel; set => _successPanel = value; }
    public GameObject StartPanel { get => _startPanel; set => _startPanel = value; }
    public Text LevelText { get => _levelText; set => _levelText = value; }
    public Text ScoreText { get => _scoreText; set => _scoreText = value; }
}
