using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private RectTransform _startScreen, _finishScreen;
    [SerializeField] private TextMeshProUGUI _scoreText;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        UpdateScore(0.ToString());
        PushFinishScrene();
    }

    public void StartButton(){
        ShiftStartScrene();
        FindObjectOfType<GameManager>().Reset();
    }
    public void AgainButton(){
        PushFinishScrene();
        FindObjectOfType<GameManager>().Reset();
    }

    public void ShiftStartScrene(){
        _startScreen.DOAnchorPos(new Vector2(-this.GetComponent<RectTransform>().sizeDelta.x - 1, 0.0f), 1, true);
    }
    public void CallFinishScreen(){
        _finishScreen.DOAnchorPos(new Vector2(0.0f, 0.0f), 1, true);
    }
    public void PushFinishScrene(){
        _finishScreen.DOAnchorPos(new Vector2(this.GetComponent<RectTransform>().sizeDelta.x + 1, 0.0f), 1, true);
    }
    public void UpdateScore(string score){
        _scoreText.text = "Score: " + score;
    }
}
