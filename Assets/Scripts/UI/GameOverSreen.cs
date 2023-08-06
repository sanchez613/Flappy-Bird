using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameOverSreen : Screen
{
    [SerializeField] private Screen _startScreen;

    public event UnityAction RestartButtonClick;
    public override void Close()
    {
        CanvasGroup.alpha = 0;
        PlayButton.interactable = false;
        AdditionalButton.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        PlayButton.interactable = true;
        AdditionalButton.interactable = true;
    }

    protected override void OnAdditionalButtonClick()
    {
        Close();
        _startScreen.Open();
    }

    protected override void OnPlayButtonClick()
    {
        RestartButtonClick?.Invoke();
    }
}
