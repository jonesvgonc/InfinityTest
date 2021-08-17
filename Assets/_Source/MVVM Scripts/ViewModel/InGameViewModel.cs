using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameViewModel : MonoBehaviour
{
    [SerializeField]
    private GameObject _inGameView;

    private InGameModel _inGameModel;

    public void StartInGameUI()
    {
        var gameObj = Instantiate(_inGameView);
        _inGameModel = gameObj.GetComponent<InGameModel>();
        EnableStartPanel();
        _inGameModel.LevelText.text = GameDataManager.Instance.ActualLevel.ToString();        
    }

    public IEnumerator DisableStartPanel()
    {
        yield return new WaitForSeconds(3);
        _inGameModel.StartPanel.SetActive(false);
    }

    public IEnumerator DisableSuccessPanel()
    {
        yield return new WaitForSeconds(5);
        _inGameModel.SuccessPanel.SetActive(false);
    }

    public void EnableStartPanel()
    {
        _inGameModel.StartPanel.SetActive(true);
        StartCoroutine(DisableStartPanel());
    }

    public void SuccessLevel()
    {
        _inGameModel.SuccessPanel.SetActive(true);
        StartCoroutine(DisableSuccessPanel());
        EnableStartPanel();
    }
}
