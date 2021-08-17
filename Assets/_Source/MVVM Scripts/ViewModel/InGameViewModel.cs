using System.Collections;
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
        AudioManager.Instance.PlayInGameMusic();
    }

    public IEnumerator DisableStartPanel()
    {
        yield return new WaitForSeconds(2f);
        _inGameModel.StartPanel.SetActive(false);
    }

    public IEnumerator DisableSuccessPanel()
    {
        yield return new WaitForSeconds(5);
        _inGameModel.SuccessPanel.SetActive(false);
        EnableStartPanel();
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
    }

    public void ChangeScoreText(int score)
    {
        _inGameModel.ScoreText.text = score.ToString();
    }

    public void ChangeLevelText()
    {
        _inGameModel.LevelText.text = GameDataManager.Instance.ActualLevel.ToString();
    }
}
