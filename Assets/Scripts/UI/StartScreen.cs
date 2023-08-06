using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : Screen
{
    [SerializeField] private ShopPanel _shopPanel;

    public event UnityAction PlayButtonClick;

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

    public void DisplayMoney(int playerMoney)
    {
        _shopPanel.DisplayMoney(playerMoney);
    }

    protected override void OnAdditionalButtonClick()
    {
        _shopPanel.gameObject.SetActive(true);
    }

    protected override void OnPlayButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}
