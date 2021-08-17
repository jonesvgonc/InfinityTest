using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelModel : MonoBehaviour
{
    [SerializeField]
    private Transform _buttonsPanel;
    [SerializeField]
    private GameObject _levelButton;

    public Transform ButtonsPanel { get => _buttonsPanel; set => _buttonsPanel = value; }
    public GameObject LevelButton { get => _levelButton; set => _levelButton = value; }
}
