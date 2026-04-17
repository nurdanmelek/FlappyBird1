
using System;
using DG.Tweening;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    public UIManager uIManager;
    
    private CanvasGroup _canvasGroup;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Hide();
            uIManager.LevelCompletedButtonPressed();
        }
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>(); 
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1, .1f);
    }


    public void Hide()
    {
        _canvasGroup.DOFade(0, .1f).OnComplete(() => gameObject.SetActive(false));  // canvas grubu gizle ve gizleme i�lemi bitti�inde objeyi tamamen kapat
    }

    public void LoadNextLevelButtonPressed()
    {
        uIManager.LoadNextLevelButtonPressed();
        Hide();
    }


    /*private void RestartButtonPressed()
    {
        uIManager.RestartButtonPressed();
    }*/
}
